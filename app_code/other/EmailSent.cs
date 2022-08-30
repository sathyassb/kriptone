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
public class EmailSent
{
    public string UserName { get; set; }
    public string MachineName { get; set; }
    public Guid EmailId { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Cc { get; set; }
    public string BCc { get; set; }
    public string Body { get; set; }
    public string Attachments { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public string ProgramName { get; set; }
    public string DomainName { get; set; }
    string url { get; set; }
    public EmailSent()
    {
        url = "EmailSent";
    }


    public List<EmailSent> GetAll(string userNames,string machineName,string fromDate,string ToDate)
    {
        tcrestconnect rest = new tcrestconnect();
        string json = rest.tcWebRequest("GET", url, "byselector/email-sent/"+userNames+"/"+machineName+"/"+fromDate+"/"+ToDate, "");
        List<EmailSent> userInfo = JsonConvert.DeserializeObject<List<EmailSent>>(json);
        return userInfo;
    }

}