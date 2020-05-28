using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Library.Data
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

        public UserDTO (Logic.User user)
        {
            this.Id = user.Id;
            this.Image = user.Image;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.Insertion = user.Insertion;
            this.LastName = user.LastName;
            this.Permission = (int)user.Permission;
            this.ZipCode = user.ZipCode;
            this.CreatedAt = user.CreatedAt;
            this.DeletedAt = user.DeletedAt;
        }
    }
}
