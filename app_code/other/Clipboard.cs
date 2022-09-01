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
public class Clipboard
{
    public string Source { get; set; }
    public string CopiedText { get; set; }
    public string CopiedFiles { get; set; }
    public string CopiedImage { get; set; }
    public string CopiedObject { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string ProgramName { get; set; }
    public string Caption { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public Clipboard()
    {
        url = "Clipboard";
    }


    public List<Clipboard> GetAll(string userNames, string machineName, string fromDate, string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/" + userNames + "/" + machineName + "/" + fromDate + "/" + ToDate, "");
        List<Clipboard> clipBoards = JsonConvert.DeserializeObject<List<Clipboard>>(json);
        return clipBoards;
    }

}

