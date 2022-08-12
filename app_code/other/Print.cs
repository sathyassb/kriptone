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
public class Print
{
    public string printId { get; set; }
    public string fileName { get; set; }
    public int noOfPages { get; set; }
    public int noOfCopies { get; set; }
    public string printerName { get; set; }
    public string userName { get; set; }
    public string machineName { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public string programName { get; set; }
    public string caption { get; set; }
    public string domainName { get; set; }
    string url { get; set; }
    public Print()
    {
        url = "Prints";
    }
   
    
    public List<Print> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<Print> emails = JsonConvert.DeserializeObject<List<Print>>(json);
        return emails;
    }

}

