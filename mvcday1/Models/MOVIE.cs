using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcday1.Models
{
    public class MOVIE
    {
        public int id { get; set; }

        [Required(ErrorMessage = "*Movie name is mandatory")]
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string Moviename { get; set; }
        //  public string Genre { get; set; }

        [Required(ErrorMessage = "*Release date is mandatory")]
        [Display(Name = "Movie Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "*Date Added is mandatory")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required(ErrorMessage = "*Available stock is mandatory")]
        [Display(Name = "Available Stock")]
        public int? AvailableStock { get; set; }

        //add reference table
        public Genre Genre { get; set; }
        //add reference column

        [Required]
        [Display(Name ="Genre")]
        public int? GenreId { get; set; }
    }
}