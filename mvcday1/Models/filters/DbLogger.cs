using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcday1.Models.filters
{
    public class DbLogger
    {
        public int id { get; set; }
        public string  ErrorMessage { get; set; }
        public string  StackTrace { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }  
        public  DateTime LogDataTime { get; set; }
    }
}