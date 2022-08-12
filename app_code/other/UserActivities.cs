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
    public string newWindowTitle { get; set; }
    public string focusedElementType { get; set; }
    public string focusChangedWindowTitle { get; set; }
    public DateTime startTime { get; set; }
    public string userName { get; set; }
    public string machineName { get; set; }
    public string domainName { get; set; }
    string url { get; set; }
    public UserActivities()
    {
        url = "UserActivities";
    }
   
    
    public List<UserActivities> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<UserActivities> emails = JsonConvert.DeserializeObject<List<UserActivities>>(json);
        return emails;
    }

}

