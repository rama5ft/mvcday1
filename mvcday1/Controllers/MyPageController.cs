using mvcday1.Models;
using mvcday1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace mvcday1.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        public ActionResult IndexPage()
      {
            string Email = TempData["Email"].ToString();
            var customer = new ApplicationDbContext().Customers.Include(c => c.MemberShipType).Include(c => c.ApplicationUser).Where(c => c.ApplicationUser.Email == Email).FirstOrDefault();
            return RedirectToAction("Index", "Customers");
        }
       

}
}