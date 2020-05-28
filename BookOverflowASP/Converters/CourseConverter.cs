using Logic = BookOverflowASP.Library.Logic;

using BookOverflowASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP
{
    public class CourseConverter
    {
        public Logic.Course ToCourse(CourseModel courseModel)
        {
            Logic.Course course = new Logic.Course();

            course.Id = courseModel.Id;
            course.Name = courseModel.Name;

            return course;
        }

        public CourseModel ToCourseModel(Logic.Course course)
        {
            CourseModel courseModel = new CourseModel();

            courseModel.Id = course.Id;
            courseModel.Name = course.Name;

            return courseModel;
        }
    }
}
