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
public class Usbs
{
    public Guid UsbId { get; set; }
    public string DeviceId { get; set; }
    public string DriveName { get; set; }
    public string SystemName { get; set; }
    public string Size { get; set; }
    public string SerialNumber { get; set; }
    public string Signature { get; set; }
    public string PNPDviceId { get; set; }
    public string Model { get; set; }
    public string MediaType { get; set; }
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Caption { get; set; }
    public bool IsDeviceAdded { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public Usbs()
    {
        url = "Usbs";
    }


    public List<Usbs> GetAll(string userNames, string machineName, string fromDate, string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/report-1/" + userNames + "/" + machineName + "/" + fromDate + "/" + ToDate, "");
        List<Usbs> Usbs = JsonConvert.DeserializeObject<List<Usbs>>(json);
        return Usbs;
    }

}

