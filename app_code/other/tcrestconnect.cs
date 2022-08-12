using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class tcrestconnect
{
    public tcrestconnect()
    {

    }

    public string tcWebRequest(string method, string url, string param, string DATA)
    {
        string host = HttpContext.Current.Request.Url.Host;
        string finalURL = (host == "localhost" ? tcReg.localurl : host.IndexOf("100")>0 ? tcReg.testurl : tcReg.liveurl) + url + "/" + param;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalURL);
        request.Method = method;
        if (method=="GET-NO-TIME-LIMIT")
        {
            request.Method = "GET";
            request.Timeout = 1000000;
        }
        
        var data = Encoding.ASCII.GetBytes(DATA);
        if (method == "POST" || method == "PUT")
        {
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        WebHeaderCollection header = response.Headers;
        var encoding = System.Text.ASCIIEncoding.UTF8;
        string responseText = "";
        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
        {
            responseText = reader.ReadToEnd();
        }
        return responseText;
    }
}



