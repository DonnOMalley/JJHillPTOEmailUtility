using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JJ_Hill_PTO_Email_Utility.Models;

namespace JJ_Hill_PTO_Email_Utility.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(new PTOEmail());
    }

    [HttpPost]
    public ActionResult Index(PTOEmail email)
    {
      try
      {
        MailGunUtility.SendSimpleMessage(email);
        return RedirectToAction("EmailSent");
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", "Error Sending Email:: " + ex.Message);
        return View(email);
      }
    }

    public ActionResult EmailSent()
    {
      return View();
    }

    public ActionResult AddAttachment()
    {
      PTOEmailAttachment attachment = new PTOEmailAttachment();
      return PartialView("~/Views/Shared/EditorTemplates/PTOEmailAttachment.cshtml", attachment);
    }
  }
}