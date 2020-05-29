using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
{
    public class BookContainer : IBookContainer
    {
        private readonly IBookDAL _bookDAL;
        private readonly ICourseContainer _courseContainer;
        private readonly ISectorContainer _sectorContainer;
        private readonly IUserContainer _userContainer;

        public BookContainer(IBookDAL bookDAL, ICourseContainer courseContainer, ISectorContainer sectorContainer, IUserContainer userContainer)
        {
            this._bookDAL = bookDAL;
            this._courseContainer = courseContainer;
            this._sectorContainer = sectorContainer;
            this._userContainer = userContainer;
        }

        public List<Book> GetAllBooks(int limit = -1)
        {
            List<BookDTO> booksDto = this._bookDAL.GetAll(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in booksDto)
            {
                // FIXME: Hoe kan dit beter?
                Course course = this._courseContainer.GetCourseById(book.Course);
                Sector sector = this._sectorContainer.GetSectorById(book.Sector);
                User user = this._userContainer.GetUserById(book.User);
                User deletedBy = this._userContainer.GetUserById(book.DeletedBy);

                books.Add(new Book(book, course, sector, user, deletedBy));
            }

            return books;
        }

        public List<Book> GetNewestBooks(int limit = -1)
        {
            List<BookDTO> bookDtos = this._bookDAL.GetNewest(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in bookDtos)
            {
                Course course = this._courseContainer.GetCourseById(book.Course);
                Sector sector = this._sectorContainer.GetSectorById(book.Sector);
                User user = this._userContainer.GetUserById(book.User);
                User deletedBy = this._userContainer.GetUserById(book.DeletedBy);
                
                books.Add(new Book(book, course, sector, user, deletedBy));
                // books.Add(new Book(book, this._courseContainer, this._sectorContainer, this._userContainer));
                // books.Add(new Book(book, this._FactoryContainer));
            }

            return books;
        }

        public Book GetBookById(int id)
        {
            BookDTO bookDto = this._bookDAL.GetById(id);

            Course course = this._courseContainer.GetCourseById(bookDto.Course);
            Sector sector = this._sectorContainer.GetSectorById(bookDto.Sector);
            User user = this._userContainer.GetUserById(bookDto.User);
            User deletedBy = this._userContainer.GetUserById(bookDto.DeletedBy);

            Book book = new Book(bookDto, course, sector, user, deletedBy);

            return book;
        }

        public bool Save(Book book)
        {
            return this._bookDAL.Save(new BookDTO(book));
        }

        public bool Update(Book book)
        {
            return this._bookDAL.Update(new BookDTO(book));
        }

        public bool Remove(int bookId, int userId)
        {
            return this._bookDAL.Remove(bookId, userId);
        }
    }
}
