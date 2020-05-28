using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
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

        public static bool Save(Course course)
        {
            return CourseDAL.Save(new CourseDTO(course));
        }

        public static bool Update(Course course)
        {
            return CourseDAL.Update(new CourseDTO(course));
        }

        public static bool Remove(int courseId, int userId) 
        {
            return CourseDAL.Remove(courseId, userId);
        }
    }
}
