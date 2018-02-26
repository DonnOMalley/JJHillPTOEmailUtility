using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JJ_Hill_PTO_Email_Utility.Models
{
  public static class MailGunUtility
  {
    public static IRestResponse SendSimpleMessage(PTOEmail email)
    {
      RestClient client = new RestClient();
      client.BaseUrl = new Uri("https://api.mailgun.net/v3");
      client.Authenticator = new HttpBasicAuthenticator("api", email.EmailAPIKey);
      RestRequest request = new RestRequest();
      request.AddParameter("domain", email.EmailDomain, ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter("from", email.FromAddress);
      request.AddParameter("to", email.ToAddress.Replace("\r\n", ",").Replace(";", ",").Replace(" ", ","));
      request.AddParameter("bcc", email.bccAddresses.Replace("\r\n", ",").Replace(";", ",").Replace(" ", ","));
      request.AddParameter("subject", email.EmailSubject);
      request.AddParameter("text", email.EmailMessage);
      request.AddParameter("html", email.HtmlEmailMessage);

      foreach (PTOEmailAttachment a in email.Attachments)
      {
        if ((a.Attachment != null) && (a.Attachment.FileName.Trim().Length > 0))
        {
          MemoryStream ms = new MemoryStream();
          a.Attachment.InputStream.CopyTo(ms);
          request.AddFile("attachment", ms.ToArray(), System.IO.Path.GetFileName(a.Attachment.FileName));
        }
      }
      request.Method = Method.POST;
      return client.Execute(request);
    }
  }
}