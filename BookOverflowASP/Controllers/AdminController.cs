using Logic = BookOverflowASP.Library.Logic;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMiddleware _middleware;

        public AdminController(IMiddleware middleware)
        {
            this._middleware = middleware;

            // Hier login voor layout
        }

        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");
            
            return View();
        }
    }
}