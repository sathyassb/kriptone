using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            idLoadUserReport();
        }
    }

    private void idLoadUserReport()
    {
        UserInfo _user = new UserInfo();
        var user = _user.GetAll();
        List<string> usernames=new List<string>();
        List<string> machinenames = new List<string>();
         foreach (UserInfo u in user)
        {
            usernames.Add(u.UserName);
            machinenames.Add(u.MachineName);
        }
        ddlUser.DataSource=usernames.Distinct();
        ddlUser.DataBind();
        ddlUser.Items.Insert(0,new ListItem("All", "-"));

        ddlMachineName.DataSource = machinenames.Distinct();
        ddlMachineName.DataBind();
        ddlMachineName.Items.Insert(0,new ListItem("All", "-"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserInfo _user = new UserInfo();
        var users = _user.GetAll();
        List<string> usernames = new List<string>();
        string filterUser = ddlUser.SelectedValue;
        string filterMachine = ddlMachineName.SelectedValue;
        DateTime filterFromDate = DateTime.Now;
        DateTime filterToDate = DateTime.Now;
        var isFromDateIsProper =
             DateTime.TryParseExact(txtDateFrom.Text, "yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out filterFromDate);

        var isToDateIsProper = DateTime.TryParseExact(txtDateTo.Text, "yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out filterToDate);

        if(!(isFromDateIsProper&&isToDateIsProper))
        {
            tclib.Toast("Please select from and to date", "error");
            return;
        }
        List<UserInfo> filteredData = new List<UserInfo>();
        filteredData = users;
        if (ddlUser.SelectedValue != "-")
        {
            filteredData = filteredData.Where(x => x.UserName == filterUser).ToList();
        }
        if (ddlMachineName.SelectedValue != "-")
        {
            filteredData = filteredData.Where(x => x.MachineName == filterMachine).ToList();
        }

        filteredData = filteredData.Where(x => x.IdleFrom > filterFromDate).ToList();
        filteredData = filteredData.Where(x => x.IdleUpTo < filterToDate).ToList();

        rptUser.DataSource = filteredData;
        rptUser.DataBind();

    }
}