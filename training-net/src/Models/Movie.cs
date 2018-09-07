using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2), Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(30), Required]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency), Range(1, 100)]   
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
