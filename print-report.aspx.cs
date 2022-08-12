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
            idLoadUserMachineGroup();
        }
    }

    private void idLoadUserMachineGroup()
    {
        HardwareDetails _hardware = new HardwareDetails();
        var hardware = _hardware.GetAll();
        List<string> usernames=new List<string>();
        List<string> machinenames = new List<string>();
         foreach (HardwareDetails u in hardware)
        {
            if (u.userName.Length > 0)
            {
                usernames.Add(u.userName);
            }
            if (u.machineName.Length > 0)
            {
                machinenames.Add(u.machineName);
            }
        }
        ddlUser.DataSource=usernames.Distinct();
        ddlUser.DataBind();
        ddlUser.Items.Insert(0,new ListItem("All Users", "-"));

        ddlMachineName.DataSource = machinenames.Distinct();
        ddlMachineName.DataBind();
        ddlMachineName.Items.Insert(0,new ListItem("All Machines", "-"));


        ddlGroupName.Items.Insert(0, new ListItem("All Groups", "-"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Print _print =new Print();
        var print = _print.GetAll();

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
        //Fitering Process. 
        List<Print> filteredData = new List<Print>();
        filteredData = print;
        if (ddlUser.SelectedValue != "-")
        {
            filteredData = filteredData.Where(x => x.userName == filterUser).ToList();
        }
        if (ddlMachineName.SelectedValue != "-")
        {
            filteredData = filteredData.Where(x => x.machineName == filterMachine).ToList();
        }

        filteredData = filteredData.Where(x => x.startTime > filterFromDate).ToList();
        filteredData = filteredData.Where(x => x.endTime < filterToDate).ToList();

        rptUser.DataSource = filteredData;
        rptUser.DataBind();

    }
}