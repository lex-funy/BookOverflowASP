using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookOverflowASP.Models;
using BookOverflowASP.Logic;
using Microsoft.AspNetCore.Http;


namespace BookOverflowASP.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");
            
            List<Course> courses = CourseContainer.GetAll();
            
            // FIXME: Kan dit beter ?
            CourseListViewModel slvm = new CourseListViewModel();
            slvm.Courses = new List<CourseModel>();
            
            foreach (Course course in courses) 
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
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseModel courseModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            CourseContainer.Save(courseModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            Course course = CourseContainer.GetCourseById(id);

            CourseModel courseModel = new CourseModel();

            courseModel.Id = course.Id;
            courseModel.Name = course.Name;

            return View(courseModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseModel courseModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            if (CourseContainer.Update(courseModel)) 
                return RedirectToAction("Index");
            return RedirectToAction("Edit", courseModel.Id);
        }

        public IActionResult Remove(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext))     
                return RedirectToAction("Login", "User");

            // TODO: Add validation message
            CourseContainer.Remove(id, SessionHandler.GetUserID(HttpContext));

            return RedirectToAction("Index");
        }
    }
}