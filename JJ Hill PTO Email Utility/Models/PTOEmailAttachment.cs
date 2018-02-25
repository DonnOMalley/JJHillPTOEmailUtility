using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JJ_Hill_PTO_Email_Utility.Models
{
  public class PTOEmailAttachment
  {
    [Display(Name = "Attachment")]
    public HttpPostedFileBase Attachment { get; set; }
  }
}