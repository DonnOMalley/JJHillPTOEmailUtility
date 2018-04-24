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

    public string EmailMessage { get; set; }

    [Display(Name = "Email Message")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string HtmlEmailMessage { get; set; }

    [Display(Name = "Attachment(s)")]
    public List<PTOEmailAttachment> Attachments { get; set; }

    public PTOEmail()
    {
      EmailDomain = Properties.Settings.Default.EmailDomain;
      EmailAPIKey = Properties.Settings.Default.EmailAPIKey;
      FromAddress = Properties.Settings.Default.DefaultFromAddress;
      ToAddress = Properties.Settings.Default.DefaultToAddress;
      Attachments = new List<PTOEmailAttachment>();

      HtmlEmailMessage = "Hello JJ Hill Community,<br>" +
                          "<br>" +
                          "<br>" +
                          "Thank you,<br>" +
                          "JJ Hill PTO<br>" +
                          "<a href = 'http://www.jjhillpto.org'> http://www.jjhillpto.org</a><br>" +
													"<a href = 'https://www.facebook.com/groups/JJHILLPTC'>https://www.facebook.com/groups/JJHILLPTC</a>" + 
                          "<br />" +
                          "<br />" +
                          "If you would rather not receive PTO emails, please send email to <a href='mailto:info@jjhillpto.org?subject=unsubscript&body=Please%20unsubscribe%20me%20from%20the%20JJ%20Hill%20PTO%20emails'>info@jjhillpto.org </a> with the subject line \"unsubscribe\"";
    }
  }
}