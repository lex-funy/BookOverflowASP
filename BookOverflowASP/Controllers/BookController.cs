using BookOverflowASP.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookOverflowASP.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            foreach (Book book in BookContainer.GetAllBooks()) 
            {
                // FIXME: Dit moet beter kunnen.
                BookModel temp = new BookModel();

                temp.Id = book.Id;

                temp.User = new UserModel();
                temp.User.Id = book.User.Id;
                temp.User.FirstName = book.User.FirstName;
                temp.User.Insertion = book.User.Insertion;
                temp.User.LastName = book.User.LastName;
                temp.User.Email = book.User.Email;

                temp.Course = new CourseModel();
                temp.Course.Id = book.Course.Id;
                temp.Course.Name = book.Course.Name;

                temp.Sector = new SectorModel();
                temp.Sector.Id = book.Sector.Id;
                temp.Sector.Name = book.Sector.Name;

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
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookContainer.Save(book);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            Book book = BookContainer.GetBookById(id);

            // FIXME: Hoe kan dit beter?
            BookModel bookModel = new BookModel();

            bookModel.Id = book.Id;

            bookModel.User = new UserModel();
            bookModel.User.Id = book.User.Id;
            bookModel.User.FirstName = book.User.FirstName;
            bookModel.User.Insertion = book.User.Insertion;
            bookModel.User.LastName = book.User.LastName;
            bookModel.User.Email = book.User.Email;

            bookModel.Course = new CourseModel();
            bookModel.Course.Id = book.Course.Id;
            bookModel.Course.Name = book.Course.Name;

            bookModel.Sector = new SectorModel();
            bookModel.Sector.Id = book.Sector.Id;
            bookModel.Sector.Name = book.Sector.Name;

            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return View(bookModel);
        }

        [HttpPost]
        public IActionResult Edit(BookModel bookModel) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookContainer.Update(bookModel);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            Book book = BookContainer.GetBookById(id);

            BookModel bookModel = new BookModel();

            // FIXME: Hoe kan dit beter?
            bookModel.Id = book.Id;

            bookModel.User = new UserModel();
            bookModel.User.Id = book.User.Id;
            bookModel.User.FirstName = book.User.FirstName;
            bookModel.User.Insertion = book.User.Insertion;
            bookModel.User.LastName = book.User.LastName;
            bookModel.User.Email = book.User.Email;

            bookModel.Course = new CourseModel();
            bookModel.Course.Id = book.Course.Id;
            bookModel.Course.Name = book.Course.Name;

            bookModel.Sector = new SectorModel();
            bookModel.Sector.Id = book.Sector.Id;
            bookModel.Sector.Name = book.Sector.Name;

            bookModel.Name = book.Name;
            bookModel.Price = book.Price;
            bookModel.QualityRating = book.QualityRating;

            return View(bookModel);
        }

        public IActionResult Remove(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            if (BookContainer.Remove(id, SessionHandler.GetUserID(HttpContext))) {
                // TODO: Add message
            }
            else 
            {
                // TODO: Add message
            }

            return RedirectToAction("Index");
        }
    }
}