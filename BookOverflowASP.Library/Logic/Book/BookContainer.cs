using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
{
    public class BookContainerSQL : IBookContainer
    {
        private readonly IBookDAL _bookDAL;

        public BookContainerSQL(IBookDAL bookDAL)
        {
            this._bookDAL = bookDAL;
        }

        public List<Book> GetAllBooks(int limit = -1)
        {
            List<BookDTO> booksDto = this._bookDAL.GetAll(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in booksDto)
            {
                books.Add(new Book(book));
            }

            return books;
        }

        public List<Book> GetNewestBooks(int limit = -1)
        {
            List<BookDTO> bookDtos = this._bookDAL.GetNewest(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in bookDtos)
            {
                books.Add(new Book(book));
            }

            return books;
        }

        public Book GetBookById(int id)
        {
            BookDTO bookDto = this._bookDAL.GetById(id);

            Book book = new Book(bookDto);

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
