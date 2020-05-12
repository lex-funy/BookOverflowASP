using System;
using BookOverflowASP.Models;
using BookOverflowASP.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int user { get; set; }
        public string Name { get; set; }
        public int QualityRating { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public BookDTO() { }

        public BookDTO(BookModel book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.QualityRating = book.QualityRating;
            this.Price = book.Price;
        }
    }
}
