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
public class UserActivities
{
    public string userActivityId { get; set; }
    public string NewWindowTitle { get; set; }
    public string FocusedElementType { get; set; }
    public string FocusChangedWindowTitle { get; set; }
    public DateTime StartTime { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public string domainName { get; set; }
    string url { get; set; }
    public UserActivities()
    {
        url = "UserActivities";
    }


    public List<UserActivities> GetAll(string userNames,string machineName,string fromDate,string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/"+userNames+"/"+machineName+"/"+fromDate+"/"+ToDate, "");
        List<UserActivities> userInfo = JsonConvert.DeserializeObject<List<UserActivities>>(json);
        return userInfo;
    }

}

