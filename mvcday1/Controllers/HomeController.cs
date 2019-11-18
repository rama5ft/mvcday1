using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcday1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string CountryName = TempData["CountryName"].ToString();
            // return Content ("CountryName:"+CountryName);
            //ViewBag.CountryName = CountryName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My  contact page.";

            return View();

        }
        public ActionResult Testing()
        {
            ViewBag.Message = "Testing is done";

            return View();
        }
            public ActionResult Example()
        {
           ViewBag.Message = "My  Example page.";

            return View();
        }
        public ActionResult  Myproject()
        {
            ViewBag.Message = "My  project page.";

            return View();
        }
        //same name passing anywhere
        public ActionResult Edit(int Empid, string Empname)
        {

            return Content("id:"+Empid +"Name:"+Empname);
        }
        //for querystring
        [Route("SearchByEmpIdandName1/{id}/{name}")]
        public ActionResult Edit1(int Empid, string Empname)
        {

            return Content($"id:{Empid},Name:{Empname}");
        }

    }
}

