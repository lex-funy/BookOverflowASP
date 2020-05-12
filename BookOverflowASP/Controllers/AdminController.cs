using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }
    }
}