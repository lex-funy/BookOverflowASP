﻿using BookOverflowASP.Library.Logic;

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

        private readonly IUserContainer _userContainer;

        public UserController(ISessionHandler sessionHandler, IMiddleware middleware, IUserContainer userContainer)
        {
            this._sessionHandler = sessionHandler;
            this._middleware = middleware;

            this._userContainer = userContainer;
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
            
            ViewData["Message"] = "Succesfully registered;";
            
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            PermissionType temp = this._sessionHandler.GetPermissionType(HttpContext);

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
            
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
                return RedirectToAction("Login", "User");

            this._sessionHandler.ClearSession(HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}