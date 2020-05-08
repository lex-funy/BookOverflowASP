using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookOverflowASP.Models;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        public IActionResult Register(UserModel userModel)
        {
            // TODO: Save the user to the database
            UserContainer.Save(userModel);
            
            ViewData["Message"] = "Succesfully registered;";
            
            return View();
        }
    }
}