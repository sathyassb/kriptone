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
            idLoadUserList();
            idLoadMachineList();
            idLoadUserReport();

        }
    }

    private void idLoadUserList()
    {
        UserList _userList = new UserList();
        ddlUser.DataSource=_userList.GetAll();
        ddlUser.DataTextField = "UserName";
        ddlUser.DataValueField = "UserName";
        ddlUser.DataBind();
    }

    private void idLoadMachineList()
    {
        MachineList _machineList = new MachineList();
        ddlMachineName.DataSource = _machineList.GetAll();
        ddlMachineName.DataTextField = "MachineName";
        ddlMachineName.DataValueField = "MachineName";
        ddlMachineName.DataBind();
    }

    private void idLoadUserReport()
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}
