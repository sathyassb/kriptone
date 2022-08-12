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
public class UserInfo
{
    public string userIdleTimeId { get; set; }
    public string userName { get; set; }
    public string machineName { get; set; }
    public int noOfMinutesIdle { get; set; }
    public int noOfMinutesActive { get; set; }
    public string userDomainName { get; set; }
    public string location { get; set; }
    public DateTime idleFrom { get; set; }
    public DateTime idleUpto { get; set; }
    public string domainName { get; set; }

    string url { get; set; }
    public UserInfo()
    {
        url = "UserIdleTime";
    }
   
    
    public List<UserInfo> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<UserInfo> userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(json);
        return userInfo;
    }

}

