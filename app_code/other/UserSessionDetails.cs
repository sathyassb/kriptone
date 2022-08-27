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
public class UserSessionDetails
{
    public Guid UserSessionDetailsId { get; set; }
    public string Version { get; set; }
    public string PublicipAddress { get; set; }
    public string IpV4 { get; set; }
    public string IpV6 { get; set; }
    public string MaxAvailableMemory { get; set; }
    public string OSArchitecture { get; set; }
    public string SerialNumber { get; set; }
    public string Manufacturer { get; set; }
    public string NoOfUsers { get; set; }
    public string FreePhysicalMemory { get; set; }
    public string BuildType { get; set; }
    public string BootDevice { get; set; }

    public string MACAddress { get; set; }
    public string UserStatus { get; set; }

    public string UserName { get; set; }
    public string MachineName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string ProgramName { get; set; }
    public string Caption { get; set; }
    public string Country { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public UserSessionDetails()
    {
        url = "UserSessionDetails";
    }


    public List<UserSessionDetails> GetAll(string userNames,string machineName,string fromDate,string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/"+userNames+"/"+machineName+"/"+fromDate+"/"+ToDate, "");
        List<UserSessionDetails> userInfo = JsonConvert.DeserializeObject<List<UserSessionDetails>>(json);
        return userInfo;
    }

}