using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcday1.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using mvcday1.Models;
using mvcday1;

namespace MVCApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminsController : Controller
    {
        private ApplicationDbContext db = null;

        public AdminsController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUserToRole()
        {
            var userViewModel = ReturnAppUserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(RoleViewModel appUser)
        {
            var userViewModel = ReturnAppUserViewModel();
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                var UserId = db.Users.Where(u => u.Email.Equals(appUser.EmailId)).Select(c => c.Id).FirstOrDefault();
                string Role = appUser.RoleName;

                if (UserId == null)
                {
                    ModelState.AddModelError("Email", "Wrong / Invalid Email ID.");
                    return View(userViewModel);
                }
                await UserManager.AddToRoleAsync(UserId, Role);
                return RedirectToAction("AddUserToRole", "Admins");
            }
            else
            {
                var roles = db.Roles.ToList();
                appUser.Roles = roles;
                return View(appUser);
            }
        }

        private ApplicationUserManager _userManager = null;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [NonAction]
        public RoleViewModel ReturnAppUserViewModel()
        {
            var appUserViewModel = new RoleViewModel();
            var roles = db.Roles.ToList();
            appUserViewModel.Roles = roles;
            return appUserViewModel;
        }
    }
}