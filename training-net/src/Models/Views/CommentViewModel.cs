using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.Views
{
    public class CommentViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [RegularExpression(@"^[*]{1,5}$"), StringLength(5, MinimumLength = 1), Required]
        public string Rating { get; set; }

        public int MovieID { get; set; }
    }
}
