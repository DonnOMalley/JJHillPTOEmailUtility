using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;


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
      EmailDomain = "jjhillpto.org";
      EmailAPIKey = "key-e6b4255d365c6a4d17987f659eb7f30b";
      FromAddress = "JJ Hill PTO <no-reply@jjhillpto.org>";
      ToAddress = "no-reply@jjhillpto.org";
      Attachments = new List<PTOEmailAttachment>();
    }
  }
}