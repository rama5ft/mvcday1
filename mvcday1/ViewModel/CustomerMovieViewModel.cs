using mvcday1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcday1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public MOVIE Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}