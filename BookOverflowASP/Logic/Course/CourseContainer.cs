using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Data;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Logic
{
    public class CourseContainer
    {
        public static List<Course> GetAll(int limit = -1)
        {
            List<CourseDTO> coursesDto = CourseDAL.GetAll(limit);

            List<Course> courses = new List<Course>();
            foreach (CourseDTO course in coursesDto) 
            {
                courses.Add(new Course(course));
            }

            return courses;
        }

        public static Course GetCourseById(int id)
        {
            return new Course(CourseDAL.GetById(id));
        }

        public static bool Save(CourseModel courseModel)
        {
            return CourseDAL.Save(new CourseDTO(courseModel));
        }

        public static bool Update(CourseModel courseModel)
        {
            return CourseDAL.Update(new CourseDTO(courseModel));
        }

        public static bool Remove(int courseId, int userId) 
        {
            return CourseDAL.Remove(courseId, userId);
        }
    }
}
