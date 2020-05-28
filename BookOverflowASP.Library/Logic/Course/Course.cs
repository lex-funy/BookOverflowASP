using System;
using BookOverflowASP.Library.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public User DeletedBy { get; set; }

        public Course() { }

        public Course(CourseDTO courseDTO, User deletedBy)
        {
            this.Id = courseDTO.Id;
            this.Name = courseDTO.Name;
            this.CreatedAt = courseDTO.CreatedAt;
            this.DeletedAt = courseDTO.DeletedAt;
            this.DeletedBy = deletedBy;            
        }
    }
}
