using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Data;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Logic
{
    public class BookContainer
    {
        public static List<Book> GetAllBooks(int limit = -1)
        {
            List<BookDTO> booksDto = BookDAL.GetAll(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in booksDto)
            {
                books.Add(new Book(book));
            }

            return books;
        }

        public static List<Book> GetNewestBooks(int limit = -1) 
        {
            List<BookDTO> bookDtos = BookDAL.GetNewest(limit);

            List<Book> books = new List<Book>();
            foreach (BookDTO book in bookDtos) 
            {
                books.Add(new Book(book));
            }

            return books;
        }

        public static Book GetBookById(int id)
        {
            BookDTO bookDto = BookDAL.GetById(id);

            Book book = new Book(bookDto);

            return book;
        }

        public static bool Save(BookModel book)
        {
            return BookDAL.Save(new BookDTO(book));
        }

        public static bool Update(BookModel book) 
        {
            return BookDAL.Update(new BookDTO(book));
        }

        public static bool Remove(int bookId, int userId) 
        {
            return BookDAL.Remove(bookId, userId);
        }
    }
}
