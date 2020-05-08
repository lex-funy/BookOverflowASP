using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookOverflowASP.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int QualityRating { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
