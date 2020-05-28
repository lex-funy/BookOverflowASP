using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
{
    public class CourseContainer : ICourseContainer
    {
        private readonly ICourseDAL _courseDal;

        public CourseContainer(ICourseDAL iCourseDal)
        {
            this._courseDal = iCourseDal;
        }

        public List<Course> GetAll(int limit = -1)
        {
            List<CourseDTO> coursesDto = this._courseDal.GetAll(limit);

            List<Course> courses = new List<Course>();
            foreach (CourseDTO course in coursesDto)
            {
                courses.Add(new Course(course));
            }

            return courses;
        }

        public Course GetCourseById(int id)
        {
            return new Course(this._courseDal.GetById(id));
        }

        public bool Save(Course course)
        {
            return this._courseDal.Save(new CourseDTO(course));
        }

        public bool Update(Course course)
        {
            return this._courseDal.Update(new CourseDTO(course));
        }

        public bool Remove(int courseId, int userId)
        {
            return this._courseDal.Remove(courseId, userId);
        }
    }
}
