using System.Collections.Generic;

namespace BookOverflowASP.Library.Data
{
    public interface ICourseDAL
    {
        List<CourseDTO> GetAll(int limit);
        CourseDTO GetById(int id);
        bool Remove(int courseId, int userId);
        bool Save(CourseDTO courseDto);
        bool Update(CourseDTO courseDto);
    }
}