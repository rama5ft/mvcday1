using mvcday1.Models;
using mvcday1.Models.filters;
using mvcday1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace mvcday1.Controllers
{
  //  [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }

        // GET: Customer
        //[AllowAnonymous]
        public ActionResult Index()
        {
            var customers = dbContext.Customers.Include(m => m.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //Customer c = new Customer();
            //var customers = GetCustomers();
            //foreach (var customer in customers)
            //{
            //    if( id== customer.id)
            //    {
            //        c = customer;
            //    }
            //}

            //return View(c);
            //linq with lambda

            var customer = dbContext.Customers.Include(m => m.MemberShipType).ToList().SingleOrDefault(a => a.id == id);
            return View(customer);
            // linq
            //var customer = from res in GetCustomers()
            //               where res.id == id
            //               select res;
            //return View(customer);
        }

        public ActionResult CustomerName()
        {
            MovieCustomerViewModel1 viewModel1 = new MovieCustomerViewModel1();
            Customer c1 = new Customer() { Customername = "Rama" };
            List<MOVIE> Movies1 = new List<MOVIE>
            {
                new MOVIE{Moviename="LoveYatri"},
                new MOVIE{ Moviename="Gangleader"},
                new MOVIE{ Moviename="Rabata"},
                new MOVIE{ Moviename="Ala Vaikuntapuram lo"},
                new MOVIE{ Moviename="Dear Comrade"},


            };

            viewModel1.customer1 = c1;
            viewModel1.Movies1 = Movies1;
            return View(viewModel1);
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{ id=1,Customername="Rama",Birthdate=Convert.ToDateTime("19/08/1998"),Gender="Female"},
                new Customer{ id=2,Customername="Janu",Birthdate=Convert.ToDateTime("22/10/1998"),Gender="Female"},
                new Customer{ id=3,Customername="Sweetie",Birthdate=Convert.ToDateTime("14/08/1998"),Gender="Female"},


            };
            return customers;
        }
        [HttpGet]
        public ActionResult Create()
        {
            var customer = new Customer();

            ViewBag.Gender = ListGender();
            ViewBag.MemberShipTypeId = ListMemberShipType();
              return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        [ExceptionLogger]
        public ActionResult Create(Customer customerFromView)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Gender = ListGender();
                ViewBag.MemberShipTypeId = ListMemberShipType();
                return View(customerFromView);
            }
            dbContext.Customers.Add(customerFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListGender()
        {
            IEnumerable<SelectListItem> gender = new List<SelectListItem>
                {
               new SelectListItem { Text = "Select a Gender", Value = "0", Disabled = true, Selected = true },
                new SelectListItem { Text = "Male", Value = "Male" },
                new SelectListItem { Text = "Female", Value = "Female" },
                new SelectListItem { Text = "Others", Value = "Others" }
            };
            return gender.ToList();
        }


        [NonAction]
        public IEnumerable<SelectListItem> ListMemberShipType()
        {
            var membership = (from m in dbContext.MemberShipTypes.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.Id.ToString()
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "----select the type---", Value = "0", Disabled = true, Selected = true });
            return membership;
        }
        [HttpGet]

        public ActionResult EditCustomerDetails(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.id == id);
            if (customer != null)
            {
                ViewBag.Gender = ListGender();
                ViewBag.MemberShipTypeId = ListMemberShipType();
                return View(customer);
            }

            return HttpNotFound("Customer Id Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditCustomerDetails(Customer customerFromView)
        {
            if(ModelState.IsValid)
            {
                var customerInDB = dbContext.Customers.FirstOrDefault(c => c.id == customerFromView.id);
                customerInDB.Customername = customerFromView.Customername;
                customerInDB.Gender = customerFromView.Gender;
                customerInDB.City = customerFromView.City;
                customerInDB.Birthdate = customerFromView.Birthdate;
                customerInDB.MemberShipTypeId = customerFromView.MemberShipTypeId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MemberShipTypeId = ListMemberShipType();
                return View(customerFromView);
            }
         
        }
        [HttpGet]
        [Authorize (Roles ="Admin")] 
        public ActionResult DeleteCustomerDetails(int id)
        {
         
                var customerInDB = dbContext.Customers.SingleOrDefault(c => c.id == id);
                if (customerInDB != null)
                {
                //dbContext.Customers.Remove(customerInDB);
                //dbContext.SaveChanges();
                //    return RedirectToAction("Index","Customers");
                ViewBag.Gender = ListGender();
                ViewBag.MemberShipTypeId = ListMemberShipType();
                return View(customerInDB);
            }

                return HttpNotFound("Customer Id Not Found");
        }

      [HttpPost]
       [ValidateAntiForgeryToken()]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCustomerDetails(Customer customerFromView)
        {
            
                var customerInDB = dbContext.Customers.FirstOrDefault(c => c.id == customerFromView.id);
                //customerInDB.Customername = customerFromView.Customername;
                //customerInDB.Gender = customerFromView.Gender;
                //customerInDB.City = customerFromView.City;
                //customerInDB.Birthdate = customerFromView.Birthdate;
                //customerInDB.MemberShipTypeId = customerFromView.MemberShipTypeId;
                dbContext.Customers.Remove(customerInDB);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
           
                
            
        }
        [HttpGet]
        public ActionResult Display()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Display(string CountryName)
        {
            TempData["CountryName"] = CountryName;
            return RedirectToAction("Index", "Home");
        }
    }
}