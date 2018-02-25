using System.Web;
using System.Web.Mvc;

namespace JJ_Hill_PTO_Email_Utility
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
