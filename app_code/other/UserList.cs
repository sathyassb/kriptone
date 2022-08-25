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
public class UserList
{
    public string UserName { get; set; }
    public string url { get; set; }
    public UserList()
    {
        url = "UserList";
    }


    public List<UserTimeSheet> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/option1/0/-/-", "");
        List<UserTimeSheet> userInfo = JsonConvert.DeserializeObject<List<UserTimeSheet>>(json);
        return userInfo;
    }

}