using System;
using BookOverflowASP.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            foreach (Book book in BookContainer.GetAllBooks()) 
            {
                BookModel temp = new BookModel();

                temp.Id = book.Id;
                temp.Name = book.Name;
                temp.Price = book.Price;
                temp.QualityRating = book.QualityRating;

                bivm.Books.Add(temp);
            }

            return View(bivm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            BookContainer.Save(book);

            // FIXME: Make this a redirect.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Book book = BookContainer.GetBookById(id);

            // FIXME: Hoe kan dit beter?
            BookModel bookModel = new BookModel();

            bookModel.Id = book.Id;
            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return View(bookModel);
        }

        [HttpPost]
        public IActionResult Edit(BookModel bookModel) 
        {
            BookContainer.Update(bookModel);

            // FIXME: Make redirect
            return View();
        }

        public IActionResult Detail(int id)
        {
            Book book = BookContainer.GetBookById(id);

            BookModel bookModel = new BookModel();

            // FIXME: Hoe kan dit beter?
            bookModel.Id = book.Id;
            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return View(bookModel);
        }
    }
}