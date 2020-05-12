using System;
using BookOverflowASP.Models;
using BookOverflowASP.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookOverflowASP.Data
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Course { get; set; }
        public int Sector { get; set; }
        public string Name { get; set; }
        public int QualityRating { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public BookDTO() { }

        public BookDTO(BookModel book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.QualityRating = book.QualityRating;
            this.Price = book.Price;
        }

        // FIXME: Mag dit??
        public BookDTO(MySqlDataReader result)
        {
            this.Id = int.Parse(result["ID"].ToString());
            this.User = int.Parse(result["user_id"].ToString());
            this.Course = int.Parse(result["course_id"].ToString());
            this.Sector = int.Parse(result["sector_id"].ToString());
            this.Name = result["name"].ToString();
            this.QualityRating = int.Parse(result["quality_rating"].ToString());
            this.Price = double.Parse(result["price"].ToString());
            this.CreatedAt = DateTime.Parse(result["created_at"].ToString());

            DateTime deletedAt = new DateTime();
            if (DateTime.TryParse(result["deleted_at"].ToString(), out deletedAt)) 
                this.DeletedAt = deletedAt;
            else 
                this.DeletedAt = DateTime.MinValue;

            int deletedBy = 0;
            if (int.TryParse(result["deleted_by"].ToString(), out deletedBy)) 
                this.DeletedBy = deletedBy;
            else 
                this.DeletedBy = 0;
        }
    }
}
