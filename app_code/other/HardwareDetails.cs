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
public class FileShadows
{
    public string FilePath { get; set; }
    public string FileSize { get; set; }
    public Guid FileShadowId { get; set; }
    public string FileType { get; set; }
    public string Source { get; set; }
    public string Destination { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public DateTime StartTime { get; set; }
    public string ProgramName { get; set; }
    public string FileName { get; set; }
    public string Caption { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public FileShadows()
    {
        url = "FileShadows";
    }


    public List<FileShadows> GetAll(string userNames, string machineName, string fromDate, string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/" + userNames + "/" + machineName + "/" + fromDate + "/" + ToDate, "");
        List<FileShadows> fileShadows = JsonConvert.DeserializeObject<List<FileShadows>>(json);
        return fileShadows;
    }

}

