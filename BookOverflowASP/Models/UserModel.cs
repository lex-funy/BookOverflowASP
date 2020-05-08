using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Insertion { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
