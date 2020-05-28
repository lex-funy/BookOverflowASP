using BookOverflowASP.Library.Logic;
using BookOverflowASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP
{
    public class BookConverter
    {
        public Book ConvertBookModelToBook(BookModel bookModel)
        {
            Book book = new Book();

            book.Id = bookModel.Id;

            book.User.Id = bookModel.User.Id;
            book.User.FirstName = bookModel.User.FirstName;
            book.User.Insertion = bookModel.User.Insertion;
            book.User.LastName = bookModel.User.LastName;
            book.User.Email = bookModel.User.Email;

            book.Course.Id = bookModel.Course.Id;
            book.Course.Name = bookModel.Course.Name;

            book.Sector.Id = bookModel.Sector.Id;
            book.Sector.Name = bookModel.Sector.Name;

            book.Name = bookModel.Name;
            book.Price = bookModel.Price;
            book.QualityRating = bookModel.QualityRating;

            return book;
        }

        public BookModel ConvertBookToBookModel(Book book)
        {
            BookModel bookModel = new BookModel();

            bookModel.Id = book.Id;

            bookModel.User.Id = book.User.Id;
            bookModel.User.FirstName = book.User.FirstName;
            bookModel.User.Insertion = book.User.Insertion;
            bookModel.User.LastName = book.User.LastName;
            bookModel.User.Email = book.User.Email;

            bookModel.Course.Id = book.Course.Id;
            bookModel.Course.Name = book.Course.Name;

            bookModel.Sector.Id = book.Sector.Id;
            bookModel.Sector.Name = book.Sector.Name;

            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return bookModel;
        }
    }
}
