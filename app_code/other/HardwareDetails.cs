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
public class HardwareDetails
{
    public string userSessionDetailId { get; set; }
    public string version { get; set; }
    public string publicIpAddress { get; set; }
    public string ipV4 { get; set; }
    public string ipV6 { get; set; }
    public string maxAvailableMemory { get; set; }
    public string osArchitecture { get; set; }
    public string serialNumber { get; set; }
    public string manufacturer { get; set; }
    public int noOfUsers { get; set; }
    public string freePhysicalMemory { get; set; }
    public string buildType { get; set; }
    public string bootDevice { get; set; }
    public string macAddress { get; set; }
    public int userStatus { get; set; }
    public string userName { get; set; }
    public string machineName { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }
    public string programName { get; set; }
    public string caption { get; set; }
    public string country { get; set; }
    public string domainName { get; set; }
    string url { get; set; }
    public HardwareDetails()
    {
        url = "PrintReport";
    }
   
    
    public List<HardwareDetails> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<HardwareDetails> userInfo = JsonConvert.DeserializeObject<List<HardwareDetails>>(json);
        return userInfo;
    }

}

