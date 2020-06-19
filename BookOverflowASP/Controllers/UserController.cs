using BookOverflowASP.Library.Logic;

using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContainer _userContainer;
        private readonly IBookContainer _bookContainer;
        private readonly ISessionHandler _sessionHandler;
        private readonly IMiddleware _middleware;

        public UserController(ISessionHandler sessionHandler, IBookContainer bookContainer, IMiddleware middleware, IUserContainer userContainer)
        {
            this._userContainer = userContainer;
            this._bookContainer = bookContainer;

            this._sessionHandler = sessionHandler;
            this._middleware = middleware;
        }
        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");
            if (this._sessionHandler.GetUserID(HttpContext) != 0)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Register(UserModel userModel)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");
            if (this._sessionHandler.GetUserID(HttpContext) != 0)
                return RedirectToAction("Index", "Home");

            // TODO: Hash the password;
            UserConverter userConverter = new UserConverter();
            this._userContainer.Save(userConverter.ToUser(userModel));
            
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            // TODO: Hash the password;
            UserConverter userConverter = new UserConverter();

            User temp = userConverter.ToUser(userLoginModel);

            User user = this._userContainer.GetByEmailAndPassword(temp);

            this._sessionHandler.SetUserId(user.Id, HttpContext);
            this._sessionHandler.SetPermission(user.Permission, HttpContext);

            PermissionType asdfasdf = this._sessionHandler.GetPermissionType(HttpContext);
            
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Logout()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            this._sessionHandler.ClearSession(HttpContext);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Cart()
        {
            List<int> ints = this._sessionHandler.GetBooksFromCart(HttpContext);

            BookIndexViewModel bivm = new BookIndexViewModel();
            bivm.Books = new List<BookModel>();

            foreach (int i in ints)
            {
                Book book = this._bookContainer.GetBookById(i);
                if (book.Name != null) 
                {
                    BookModel temp = new BookModel();

                    temp.Id = book.Id;
                    temp.Name = book.Name;
                    temp.Price = book.Price;
                    temp.QualityRating = book.QualityRating;

                    bivm.Books.Add(temp);
                }
            }

            return View(bivm);
        }

        [HttpPost]
        public IActionResult Cart(int bookId)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");


            this._sessionHandler.AddBookToCart(bookId, HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}