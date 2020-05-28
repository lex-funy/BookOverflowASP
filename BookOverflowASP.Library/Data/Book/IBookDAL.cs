using System.Collections.Generic;

namespace BookOverflowASP.Library.Data
{
    public interface IBookDAL
    {
        List<BookDTO> GetAll(int limit);
        BookDTO GetById(int id);
        List<BookDTO> GetNewest(int limit);
        bool Remove(int bookId, int userId);
        bool Save(BookDTO bookDto);
        bool Update(BookDTO bookDto);
    }
}