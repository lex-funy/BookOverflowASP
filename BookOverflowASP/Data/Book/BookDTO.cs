using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class BookDTO
    {
        public int Id;
        public string Name;
        public int QualityRating;
        public double Price;
        public DateTime CreatedAt;
        public DateTime DeletedAt;

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
