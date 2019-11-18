using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcday1.Models;
using mvcday1.ViewModel;
using System.Data.Entity;

namespace mvcday1.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
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
        public object Movie { get; private set; }

        // GET: Movies
        [AllowAnonymous]
        public ActionResult MovieIndexs()
        {
            var movies = dbContext.Movies.Include(g => g.Genre).ToList();
            return View(movies);

        }
        public ActionResult MovieDetails(int id)
        {

            var movie = dbContext.Movies.Include(g => g.Genre).ToList().SingleOrDefault(a => a.id == id);
            return View(movie);

        }
        public ActionResult MovieName()
        {
            //MOVIE mv= new MOVIE() { name="Gangleader"};
            //    return View(mv);
            CustomerMovieViewModel viewModel = new CustomerMovieViewModel();
            MOVIE m1 = new MOVIE() { Moviename = "GangLeader" };
            List<Customer> Customers = new List<Customer>
            {
                new Customer{ Customername="Rama"},
                new Customer{ Customername="Thanmayi"},
                new Customer{ Customername="Suchi"},
                new Customer{ Customername="Mouni"},
                new Customer{ Customername="Vaishu"},


            };
            viewModel.Movie = m1;
            viewModel.Customers = Customers;
            return View(viewModel);
        }
        //public List<MOVIE> GetMovieDetails()
        //{
        //    List<MOVIE> movies = new List<MOVIE>
        //    {
        //        new MOVIE{ id =1,Moviename="Loveyatri", Genre="Love Movie",ReleaseDate=Convert.ToDateTime("01/01/2017"),DateAdded=Convert.ToDateTime("02/02/2017") },
        //        new MOVIE{ id =2,Moviename="Gangleader", Genre="Revenge",ReleaseDate=Convert.ToDateTime("02/05/2019"),DateAdded=Convert.ToDateTime("05/06/2019") },
        //        new MOVIE{ id =3,Moviename="maharshi", Genre="success",ReleaseDate=Convert.ToDateTime("05/03/2019"),DateAdded=Convert.ToDateTime("06/08/2019") },
        //        new MOVIE{ id =4,Moviename="Aarya", Genre="Love",ReleaseDate=Convert.ToDateTime("02/06/2002"),DateAdded=Convert.ToDateTime("25/05/2003") },

        //        };


        //    return movies;
        //}

        [HttpGet]
      
        public ActionResult Createm()
        {
            var movie = new MOVIE();
            ViewBag.GenreId = ListGenre();


            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Createm(MOVIE movieFromView)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.GenreId = ListGenre();
                return View(movieFromView);
            }
            dbContext.Movies.Add(movieFromView);
            dbContext.SaveChanges();
            return RedirectToAction("MovieIndexs", "Movies");

        }
        public IEnumerable<SelectListItem> ListGenre()
        {
            var gType = dbContext.Genres.AsEnumerable().
           Select(m => new SelectListItem()
           {
               Text = m.Name,
               Value = m.Id.ToString()
           }).ToList();

            gType.Insert(0, new SelectListItem { Text = "----select the type---", Value = "0", Disabled = true, Selected = true });
            return gType;
        }
        [HttpGet]
        public ActionResult EditMovieDetails(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.id == id);
            if (movie != null)
            {

                ViewBag.GenreId = ListGenre();
                return View(movie);
            }

            return HttpNotFound("Movie Id Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditMovieDetails(MOVIE movieFromView)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.GenreId = ListGenre();
                var movieInDB = dbContext.Movies.FirstOrDefault(c => c.id == movieFromView.id);
                movieInDB.Moviename = movieFromView.Moviename;
                movieInDB.ReleaseDate = movieFromView.ReleaseDate;
                movieInDB.DateAdded = movieFromView.DateAdded;
                movieInDB.GenreId = movieFromView.GenreId;
                movieInDB.AvailableStock = movieFromView.AvailableStock;
                dbContext.SaveChanges();
                return RedirectToAction("MovieIndexs", "Movies");
            }
            else
            {

                ViewBag.GenreId = ListGenre();
               
                return View(movieFromView);
            }
        }
        [HttpGet]
        public ActionResult DeleteMovieDetails(int id)
        {
            var movieInDB = dbContext.Movies.SingleOrDefault(c => c.id == id);
            if (movieInDB != null)
            {
                //dbContext.Customers.Remove(customerInDB);
                //dbContext.SaveChanges();
                //    return RedirectToAction("Index","Customers");

                ViewBag.GenreId = ListGenre();
                return View(movieInDB);
            }

            return HttpNotFound("Movie Id Not Found");
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteCustomerDetails(MOVIE movieFromView)
        {

            var movieInDB = dbContext.Movies.FirstOrDefault(c => c.id == movieFromView.id);
            dbContext.Movies.Remove(movieInDB);
            dbContext.SaveChanges();
            return RedirectToAction("MovieIndexs", "Movies");
        }
    }

}
