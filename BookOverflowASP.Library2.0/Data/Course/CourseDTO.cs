using Logic = BookOverflowASP.Library.Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Library.Data
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public CourseDTO() { }

        public CourseDTO (Logic.Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
        }

    }
}
