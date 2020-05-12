using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Quality rating")]
        public int QualityRating { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
