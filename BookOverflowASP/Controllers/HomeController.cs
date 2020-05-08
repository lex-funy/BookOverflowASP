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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
