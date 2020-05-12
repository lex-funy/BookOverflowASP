using System;
using BookOverflowASP.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

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
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            BookContainer.Save(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

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
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            BookContainer.Update(bookModel);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            Book book = BookContainer.GetBookById(id);

            BookModel bookModel = new BookModel();

            // FIXME: Hoe kan dit beter?
            bookModel.Id = book.Id;
            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return View(bookModel);
        }

        public IActionResult Remove(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            if (BookContainer.Remove(id, SessionHandler.GetUserID(HttpContext))) {
                // Ging goed
            }
            else 
            {
                // Ging niet zo goed.
            }

            return RedirectToAction("Index");
        }
    }
}