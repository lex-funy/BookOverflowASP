using Logic = BookOverflowASP.Library.Logic;

using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace BookOverflowASP.Controllers
{
    public class CourseController : Controller
    {
        private readonly ISessionHandler _sessionHandler;
        private readonly IMiddleware _middleware;


        public CourseController(ISessionHandler sessionHandler, IMiddleware middleware)
        {
            this._sessionHandler = sessionHandler;
            this._middleware = middleware;
        }

        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");
            
            List<Logic.Course> courses = Logic.CourseContainer.GetAll();
            
            // FIXME: Kan dit beter ?
            CourseListViewModel slvm = new CourseListViewModel();
            slvm.Courses = new List<CourseModel>();
            
            foreach (Logic.Course course in courses) 
            {
                CourseModel temp = new CourseModel();

                temp.Id = course.Id;
                temp.Name = course.Name;

                slvm.Courses.Add(temp);
            }

            return View(slvm);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseModel courseModel)
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            CourseConverter courseConverter = new CourseConverter();
            Logic.CourseContainer.Save(courseConverter.ToCourse(courseModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            Logic.Course course = Logic.CourseContainer.GetCourseById(id);

            CourseModel courseModel = new CourseModel();

            courseModel.Id = course.Id;
            courseModel.Name = course.Name;

            return View(courseModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseModel courseModel)
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext))
                return RedirectToAction("Login", "User");

            CourseConverter courseConverter = new CourseConverter();
            if (Logic.CourseContainer.Update(courseConverter.ToCourse(courseModel))) 
                return RedirectToAction("Index");
            return RedirectToAction("Edit", courseModel.Id);
        }

        public IActionResult Remove(int id) 
        {
            if (!this._middleware.CheckUserPermission(Logic.PermissionType.Admin, HttpContext))     
                return RedirectToAction("Login", "User");

            // TODO: Add validation message
            Logic.CourseContainer.Remove(id, this._sessionHandler.GetUserID(HttpContext));

            return RedirectToAction("Index");
        }
    }
}