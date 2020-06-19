using BookOverflowASP.Library.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookContainer _bookContainer;
        private readonly ISectorContainer _sectorContainer;
        private readonly ICourseContainer _courseContainer;
        private readonly ISessionHandler _sessionHandler; 
        private readonly IMiddleware _middleware;

        public BookController(IBookContainer bookContainer, ISectorContainer sectorContainer, ICourseContainer courseContainer, ISessionHandler sessionHandler, IMiddleware middleware)
        {
            this._bookContainer = bookContainer;
            this._sectorContainer = sectorContainer;
            this._courseContainer = courseContainer;

            this._sessionHandler = sessionHandler;
            this._middleware = middleware;
        }

        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            BookConverter bookConverter = new BookConverter();
            foreach (Book book in this._bookContainer.GetBooksByUserID(this._sessionHandler.GetUserID(HttpContext)))
                bivm.Books.Add(bookConverter.ConvertBookToBookModel(book));

            return View(bivm);
        }

        [HttpGet]
        public IActionResult Search()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            BookConverter bookConverter = new BookConverter();
            foreach (Book book in this._bookContainer.GetBookByName(name))
                bivm.Books.Add(bookConverter.ConvertBookToBookModel(book));

            return View(bivm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            // return all sectors
            SectorConverter sectorConverter = new SectorConverter();
            ViewData["Sectors"] = sectorConverter.ToSectorModelList(this._sectorContainer.GetAll());

            // return all courses
            CourseConverter courseConverter = new CourseConverter();
            ViewData["Courses"] = courseConverter.ToCourseModelList(this._courseContainer.GetAll());

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel bookModel)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            bookModel.User.Id = this._sessionHandler.GetUserID(HttpContext);

            BookConverter bookConverter = new BookConverter();
            this._bookContainer.Save(bookConverter.ConvertBookModelToBook(bookModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            SectorConverter sectorConverter = new SectorConverter();
            ViewData["Sectors"] = sectorConverter.ToSectorModelList(this._sectorContainer.GetAll());

            CourseConverter courseConverter = new CourseConverter();
            ViewData["Courses"] = courseConverter.ToCourseModelList(this._courseContainer.GetAll());

            Book book = this._bookContainer.GetBookById(id);

            BookConverter bookConverter = new BookConverter();
            BookModel bookModel = bookConverter.ConvertBookToBookModel(book);

            return View(bookModel);
        }

        [HttpPost]
        public IActionResult Edit(BookModel bookModel) 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            BookConverter bookConverter = new BookConverter();
            this._bookContainer.Update(bookConverter.ConvertBookModelToBook(bookModel));

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            Book book = this._bookContainer.GetBookById(id);

            BookConverter bookConverter = new BookConverter();

            BookModel bookModel = bookConverter.ConvertBookToBookModel(book);

            return View(bookModel);
        }

        public IActionResult Order()
        {
            // Add order to order table
            // User owner = this._bookContainer.GetUserForBookByID(int id);

            // Remove current books in session
            int userId = this._sessionHandler.GetUserID(HttpContext);
            List<int> ints = this._sessionHandler.GetBooksFromCart(HttpContext);

            foreach (int i in ints)
            {
                this._bookContainer.Remove(i, userId);
            }

            // Clear current books in session
            this._sessionHandler.ClearBooks(HttpContext);
            
            return View();
        }

        public IActionResult Remove(int id) 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            if (this._bookContainer.Remove(id, this._sessionHandler.GetUserID(HttpContext))) {
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