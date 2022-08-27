﻿using System;
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
            idLoadDefaultDateTime();


        }
    }

    private void idLoadDefaultDateTime()
    {
        txtDateFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
        txtDateTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
    }

    private void idLoadUserList()
    {
        UserList _userList = new UserList();
        var userList = _userList.GetAll();



        lbxUser.DataSource = userList;
        lbxUser.DataValueField = "UserName";
        lbxUser.DataTextField = "UserName";
        lbxUser.DataBind();

    }

    private void idLoadMachineList()
    {
        MachineList _machineList = new MachineList();
        var userList = _machineList.GetAll();
        ddlMachineName.DataSource = userList;
        ddlMachineName.DataValueField = "MachineName";
        ddlMachineName.DataTextField = "MachineName";
        ddlMachineName.DataBind();
        ddlMachineName.Items.Insert(0, new ListItem("ALL", "-"));

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserTimeSheet _timesheet = new UserTimeSheet();
        string userNames = string.Empty;
        foreach (ListItem ls in lbxUser.Items)
        {
            if (ls.Selected)
            {
                userNames += ls.Value + ",";
            }

        }
        userNames = userNames.TrimEnd(',');
        userNames = userNames == "" ? "-" : userNames;
        DateTime filterFromDate = DateTime.Now;
        DateTime filterToDate = DateTime.Now;
        var isFromDateIsProper =
             DateTime.TryParseExact(txtDateFrom.Text, "yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out filterFromDate);

        var isToDateIsProper = DateTime.TryParseExact(txtDateTo.Text, "yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out filterToDate);

        if (!(isFromDateIsProper && isToDateIsProper))
        {
            tclib.Toast("Please select a valid from and to date", "error");
            return;
        }
        if (filterToDate<filterFromDate)
        {
            tclib.Toast("Please select to date greater than from date", "error");
            return;
        }
        var users = _timesheet.GetAll(userNames, ddlMachineName.SelectedValue, filterFromDate.ToString("yyyy-MM-dd"), filterToDate.ToString("yyyy-MM-dd"));
        rptUser.DataSource = users;
        rptUser.DataBind();
        int totalMinutes = 0;
        users.ForEach(x =>totalMinutes+=x.TotalMinutes);

        int idleMinutes = 0;
        users.ForEach(x => idleMinutes += x.IdleMinutes);
        Title = "User:" + userNames + " From : "+txtDateFrom.Text+" To : "+txtDateTo.Text+"\n\rTotal Time: "+
            ((new  TimeSpan(0,totalMinutes-idleMinutes,0).Days*24+ new TimeSpan(0, totalMinutes-idleMinutes, 0).Hours)+"h:"+ new TimeSpan(0, totalMinutes-idleMinutes, 0).Minutes+"m");

    }

    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        idLoadMachineList();
    }
}