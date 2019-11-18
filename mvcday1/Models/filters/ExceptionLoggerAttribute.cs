using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcday1.Models.filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                DbLogger dbLogger = new DbLogger()
                {
                    ErrorMessage = filterContext.Exception.Message,
                    StackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    ActionName = filterContext.RouteData.Values["action"].ToString(),
                    LogDataTime = DateTime.Now
                };
                ApplicationDbContext db = new ApplicationDbContext();
                db.DbLoggers.Add(dbLogger);
                db.SaveChanges();
                filterContext.ExceptionHandled = true;

            }
        }
    }
}