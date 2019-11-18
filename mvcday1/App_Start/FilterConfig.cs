using mvcday1.Models.filters;
using System.Web;
using System.Web.Mvc;

namespace mvcday1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLoggerAttribute());
        }
    }
}
