﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserIdleTime
{
    public Guid UserIdleTimeId { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public long NoOfMinutesIdle { get; set; }
    public long NoOfMinutesActive { get; set; }
    public string UserDomainName { get; set; }
    public string Location { get; set; }
    public DateTime IdleFrom { get; set; }
    public DateTime IdleUpTo { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public UserIdleTime()
    {
        url = "UserIdleTime";
    }


    public List<UserIdleTime> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/option1/0/-/-", "");
        List<UserIdleTime> userInfo = JsonConvert.DeserializeObject<List<UserIdleTime>>(json);
        return userInfo;
    }

}