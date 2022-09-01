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
public class Applications
{
    public int AppId { get; set; }
    public int ParentAppId { get; set; }
    public Guid ApplicationInfold { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public string Started { get; set; }
    public bool IsMetroApp { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TotalTime { get; set; }
    public string ProgramName { get; set; }
    public string Caption { get; set; }
    public string Description { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public Applications()
    {
        url = "Applications";
    }


    public List<Applications> GetAll(string userNames, string machineName, string fromDate, string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/" + userNames + "/" + machineName + "/" + fromDate + "/" + ToDate, "");
        List<Applications> applications = JsonConvert.DeserializeObject<List<Applications>>(json);
        return applications;
    }

}

