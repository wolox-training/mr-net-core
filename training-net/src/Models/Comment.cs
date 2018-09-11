using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Rating { get; set; }
<<<<<<< 2e340beca05f69e4ef0c3d5b0dd2475807719245
        
        public Movie Movie { get; set; }
=======
        public int MovieID { get; set; }
>>>>>>> comments view 3
    }
}
