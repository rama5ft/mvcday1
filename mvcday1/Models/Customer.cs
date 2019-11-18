using mvcday1.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcday1.Models
{
    public class Customer
    {//domain class or model
        
        public int id { get; set; }

        [Required(ErrorMessage = "*Customer name is mandatory")]
        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string Customername { get; set; }

        [Required(ErrorMessage = "*Date of birth is needed")]
        [Display(Name="Date Of Birth")]
        [ValidDateOfBirth]
        public DateTime?Birthdate { get; set; }


        [Required(ErrorMessage = "*Gender is mandatory")]
        [StringLength(8)]
        [Column(TypeName = "char")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*City is mandatory")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }
       
        //add reference table
        public MemberShipType MemberShipType { get; set; }
       
        //add reference column
        [Required(ErrorMessage ="* mandatory")]
        [Display(Name = "MemberShip Type")]
        public int? MemberShipTypeId { get; set; }

        //add refernce table
        public ApplicationUser ApplicationUser { get; set; }
        // add ref column
        public int? ApplicationUserId { get; set; }
    }

}