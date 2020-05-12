using System;
using BookOverflowASP.Data;
using BookOverflowASP.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class Book
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int QualityRating { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public Book() { }

        public Book(BookDTO bookDTO)
        {
            this.Id = bookDTO.Id;
            // this.User = UserContainer.GetUserById(bookDTO.Id);
            this.Name = bookDTO.Name;
            this.QualityRating = bookDTO.QualityRating;
            this.Price = bookDTO.Price;
            this.CreatedAt = bookDTO.CreatedAt;
            this.DeletedAt = bookDTO.DeletedAt;
        }

        public Book(BookModel bookModel) {
            this.Id = bookModel.Id;
            this.Name = bookModel.Name;
            this.QualityRating = bookModel.QualityRating;
            this.Price = bookModel.Price;
        }
    }
}
