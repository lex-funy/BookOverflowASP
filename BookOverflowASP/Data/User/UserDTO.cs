using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }
        public int Permission { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public UserDTO() { }

        public UserDTO (UserModel userModel)
        {
            this.Id = userModel.Id;
            this.Email = userModel.Email;
            this.Password = userModel.Password;
            this.FirstName = userModel.FirstName;
            this.Insertion = userModel.Insertion;
            this.LastName = userModel.LastName;
        }

    }
}
