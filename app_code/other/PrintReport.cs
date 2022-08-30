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
public class PrintReport
{
    public Guid PrintId { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }

    public string FileName { get; set; }
    public int NoOfPages { get; set; }
    public int NoOfCopies { get; set; }
    public string PrinterName { get; set; }
    public DateTime StartTime { get; set; }
    public string ProgramName { get; set; }

    public string Caption { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public PrintReport()
    {
        url = "PrintReport";
    }


    public List<PrintReport> GetAll(string userNames,string machineName,string fromDate,string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/"+userNames+"/"+machineName+"/"+fromDate+"/"+ToDate, "");
        List<PrintReport> userInfo = JsonConvert.DeserializeObject<List<PrintReport>>(json);
        return userInfo;
    }

}

