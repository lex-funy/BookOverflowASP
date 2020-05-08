using System;
using BookOverflowASP.Data;
using BookOverflowASP.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QualityRating { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public User() { }

        public User(UserDTO UserDTO)
        {
            throw new NotImplementedException();
        }

        public User(UserModel UserModel) 
        {
            throw new NotImplementedException();
        }
    }
}
