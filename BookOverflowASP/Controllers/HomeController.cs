using System.Diagnostics;
using BookOverflowASP.Library.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookContainer _bookContainer;
        private readonly IMiddleware _middleware;

        public HomeController(IBookContainer bookContainer, IMiddleware middleware)
        {
            this._bookContainer = bookContainer;
            this._middleware = middleware;
        }

        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            foreach (Book book in this._bookContainer.GetNewestBooks(8))
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
    }
}