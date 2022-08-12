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
public class Email
{
    public string emailId { get; set; }
    public string to { get; set; }
    public string from { get; set; }
    public string cc { get; set; }
    public string bCc { get; set; }
    public string body { get; set; }
    public string attachments { get; set; }
    public string subject { get; set; }
    public string userName { get; set; }
    public string machineName { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public string programName { get; set; }
    public string caption { get; set; }
    public string domainName { get; set; }
    string url { get; set; }
    public Email()
    {
        url = "Emails";
    }
   
    
    public List<Email> GetAll()
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "", "");
        List<Email> emails = JsonConvert.DeserializeObject<List<Email>>(json);
        return emails;
    }

}

