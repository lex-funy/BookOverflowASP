using System;
using BookOverflowASP.Data;
using BookOverflowASP.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public User DeletedBy { get; set; }

        public Course() { }

        public Course(CourseDTO courseDTO)
        {
            this.Id = courseDTO.Id;
            this.Name = courseDTO.Name;
            this.CreatedAt = courseDTO.CreatedAt;
            this.DeletedAt = courseDTO.DeletedAt;
            this.DeletedBy = UserContainer.GetUserById(courseDTO.DeletedBy);            
        }

        public Course(CourseModel courseModel) 
        {
            throw new NotImplementedException();
        }
    }
}
