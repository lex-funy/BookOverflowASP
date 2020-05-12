using System.Diagnostics;
using BookOverflowASP.Logic;
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
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            foreach (Book book in BookContainer.GetNewestBooks(8))
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