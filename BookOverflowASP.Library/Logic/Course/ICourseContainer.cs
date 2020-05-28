using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public interface ICourseContainer
    {
        List<Course> GetAll(int limit = -1);
        Course GetCourseById(int id);
        bool Remove(int courseId, int userId);
        bool Save(Course course);
        bool Update(Course course);
    }
}