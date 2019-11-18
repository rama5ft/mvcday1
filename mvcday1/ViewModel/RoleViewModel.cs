using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcday1.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="EmailAddress")]
        public string EmailId { get; set; }
       [Required]
        [Display(Name =" Assign a Role")]
        public ICollection<IdentityRole> Roles { get; set; }
        public string RoleName { get; set; }
    }
}