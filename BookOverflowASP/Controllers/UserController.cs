using System;
using BookOverflowASP.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.User, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        public IActionResult Register(UserModel userModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            // TODO: Hash the password;
            UserContainer.Save(userModel);
            
            ViewData["Message"] = "Succesfully registered;";
            
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            // TODO: Hash the password;
            User user = UserContainer.GetByEmailAndPassword(userLoginModel);

            SessionHandler.SetUserId(user.Id, HttpContext);
            SessionHandler.SetPermission(user.Permission, HttpContext);

            if (user.Permission == PermissionType.Admin)
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Logout()
        {
            if (!Middleware.CheckUserPermission(PermissionType.None, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            SessionHandler.ClearSession(HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}