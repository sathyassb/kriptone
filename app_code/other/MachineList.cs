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
public class MachineList
{
    public string UserName { get; set; }
    public string url { get; set; }
    public MachineList()
    {
        url = "MachineList";
    }


    public List<MachineList> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<MachineList> userInfo = JsonConvert.DeserializeObject<List<MachineList>>(json);
        return userInfo;
    }

}