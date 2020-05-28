using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public interface IBookContainer
    {
        List<Book> GetAllBooks(int limit = -1);
        Book GetBookById(int id);
        List<Book> GetNewestBooks(int limit = -1);
        bool Remove(int bookId, int userId);
        bool Save(Book book);
        bool Update(Book book);
    }
}