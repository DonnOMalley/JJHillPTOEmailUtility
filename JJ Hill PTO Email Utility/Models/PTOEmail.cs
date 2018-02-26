using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using System;

namespace JJ_Hill_PTO_Email_Utility.Models
{
  public class PTOEmail
  {
    [Display(Name = "Email Domain")]
    [Required]
    public string EmailDomain { get; set; }
    [Display(Name = "API Key")]
    [Required]
    public string EmailAPIKey { get; set; }

    [Display(Name = "From Email")]
    [AllowHtml]
    [Required]
    public string FromAddress { get; set; }
    [Display(Name = "\"To\" Email List")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string ToAddress { get; set; }

    [Display(Name = "\"bcc\" Email List")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string bccAddresses { get; set; }
    [Display(Name = "Subject")]
    [Required]
    public string EmailSubject { get; set; }
    [Display(Name = "Email Message")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string EmailMessage { get; set; }
    [Display(Name = "Attachment(s)")]
    public List<PTOEmailAttachment> Attachments { get; set; }

    public PTOEmail()
    {
      EmailDomain = Properties.Settings.Default.EmailDomain;
      EmailAPIKey = Properties.Settings.Default.EmailAPIKEy;
      FromAddress = Properties.Settings.Default.DefaultFromAddress;
      ToAddress = Properties.Settings.Default.DefaultToAddress;
      Attachments = new List<PTOEmailAttachment>();

      EmailMessage = Environment.NewLine +
                            Environment.NewLine +
                            "Thank you," + Environment.NewLine +
                            "JJ Hill PTO" + Environment.NewLine +
                            Properties.Settings.Default.WebsiteAddress + Environment.NewLine +
                            Properties.Settings.Default.FacebookGroupAddress + Environment.NewLine +
                            Environment.NewLine +
                            "If you would rather not receive PTO emails, please email info@jjhillpto.org with the subject of \"unsubscribe\"";

    }
  }
}