using System;
using BookOverflowASP.Library.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public class User
    {        
        public int Id { get; set; }

        // TODO: Implement Image
        public int Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }
        public PermissionType Permission { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public User DeletedBy { get; set; }

        public User() { }

        public User(UserDTO userDTO, User deletedBy)
        {
            this.Id = userDTO.Id;
            this.Image = userDTO.Image;
            this.Password = userDTO.Password;
            this.FirstName = userDTO.FirstName;
            this.Insertion = userDTO.Insertion;
            this.LastName = userDTO.LastName;
            this.Permission = (PermissionType)userDTO.Permission;
            this.ZipCode = userDTO.ZipCode;
            this.CreatedAt = userDTO.CreatedAt;
            this.DeletedAt = userDTO.DeletedAt;
            this.DeletedBy = deletedBy;
        }
    }
}
