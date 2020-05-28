using System;
using BookOverflowASP.Library.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public class Book
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
        public Sector Sector { get; set; }
        public string Name { get; set; }
        public int QualityRating { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public User DeletedBy { get; set; }

        public Book() 
        {
            this.User = new User();
            this.Course = new Course();
            this.Sector = new Sector();
        }

        public Book(BookDTO bookDTO)
        {
            this.Id = bookDTO.Id;
            this.User = UserContainer.GetUserById(bookDTO.User);
            this.Course = CourseContainer.GetCourseById(bookDTO.Course);
            this.Sector = SectorContainer.GetSectorById(bookDTO.Sector);
            this.Name = bookDTO.Name;
            this.QualityRating = bookDTO.QualityRating;
            this.Price = bookDTO.Price;
            this.CreatedAt = bookDTO.CreatedAt;
            this.DeletedAt = bookDTO.DeletedAt;
            this.DeletedBy = UserContainer.GetUserById(bookDTO.DeletedBy);
        }
    }
}
