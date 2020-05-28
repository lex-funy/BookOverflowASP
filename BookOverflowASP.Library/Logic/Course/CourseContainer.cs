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
        private readonly IUserContainer _userContainer;

        public CourseContainer(ICourseDAL iCourseDal, IUserContainer userContainer)
        {
            this._courseDal = iCourseDal;
            this._userContainer = userContainer;
        }

        public List<Course> GetAll(int limit = -1)
        {
            List<CourseDTO> coursesDto = this._courseDal.GetAll(limit);

            List<Course> courses = new List<Course>();
            foreach (CourseDTO course in coursesDto)
            {
                User deletedBy = this._userContainer.GetUserById(course.DeletedBy);

                courses.Add(new Course(course, deletedBy));
            }

            return courses;
        }

        public Course GetCourseById(int id)
        {
            CourseDTO courseDTO = this._courseDal.GetById(id);
            User deletedBy = this._userContainer.GetUserById(courseDTO.DeletedBy);

            return new Course(courseDTO, deletedBy);
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
