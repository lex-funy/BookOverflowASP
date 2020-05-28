using Logic = BookOverflowASP.Library.Logic;

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
        private readonly ISessionHandler _sessionHandler;
        private readonly IMiddleware _middleware;

        public UserController(ISessionHandler sessionHandler, IMiddleware middleware)
        {
            this._sessionHandler = sessionHandler;
            this._middleware = middleware;
        }
        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.User, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");
            if (this._sessionHandler.GetUserID(HttpContext) != 0)
                return RedirectToAction("Index", "Home");


            return View();
        }

        public IActionResult Register(UserModel userModel)
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");
            if (this._sessionHandler.GetUserID(HttpContext) != 0)
                return RedirectToAction("Index", "Home");

            // TODO: Hash the password;
            UserConverter userConverter = new UserConverter();
            Logic.UserContainer.Save(userConverter.ToUser(userModel));
            
            ViewData["Message"] = "Succesfully registered;";
            
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            // TODO: Hash the password;
            UserConverter userConverter = new UserConverter();
            Logic.User user = Logic.UserContainer.GetByEmailAndPassword(userConverter.ToUser(userLoginModel));

            this._sessionHandler.SetUserId(user.Id, HttpContext);
            this._sessionHandler.SetPermission(user.Permission, HttpContext);

            // this._sessionHandler.SetUserId(1, HttpContext);
            // this._sessionHandler.SetPermission(Logic.PermissionType.Admin, HttpContext);

            return Redirect("Index");
        }

        public IActionResult Logout()
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            this._sessionHandler.ClearSession(HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}