using Newtonsoft.Json;
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
public class UserTimeSheet
{
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string LogoffTime { get; set; }
    public int TotalMinutes { get; set; }
    public int IdleMinutes { get; set; }
    string url { get; set; }
    public UserTimeSheet()
    {
        url = "UserTimeSheet";
    }


    public List<UserTimeSheet> GetAll(string userNames,string machineName,string type,string fromDate,string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/time-sheet/"+userNames+"/"+machineName+"/"+type+"/"+fromDate+"/"+ToDate, "");
        List<UserTimeSheet> userInfo = JsonConvert.DeserializeObject<List<UserTimeSheet>>(json);
        return userInfo;
    }

}