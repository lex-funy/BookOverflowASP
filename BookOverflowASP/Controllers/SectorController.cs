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
    public class SectorController : Controller
    {
        public IActionResult Index()
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");
            
            List<Sector> sectors = SectorContainer.GetAll();
            
            // FIXME: Kan dit beter ?
            SectorListViewModel slvm = new SectorListViewModel();
            slvm.Sectors = new List<SectorModel>();
            
            foreach (Sector sector in sectors) 
            {
                SectorModel temp = new SectorModel();

                temp.Id = sector.Id;
                temp.Name = sector.Name;

                slvm.Sectors.Add(temp);
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
        public IActionResult Create(SectorModel sectorModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            SectorContainer.Save(sectorModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            Sector sector = SectorContainer.GetSectorById(id);

            SectorModel sectorModel = new SectorModel();

            sectorModel.Id = sector.Id;
            sectorModel.Name = sector.Name;

            return View(sectorModel);
        }

        [HttpPost]
        public IActionResult Edit(SectorModel sectorModel)
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            if (SectorContainer.Update(sectorModel)) 
                return RedirectToAction("Index");
            return RedirectToAction("Edit", sectorModel.Id);
        }

        public IActionResult Remove(int id) 
        {
            if (!Middleware.CheckUserPermission(PermissionType.Admin, HttpContext))     
                return RedirectToAction("Login", "User");

            // TODO: Add validation message
            SectorContainer.Remove(id, SessionHandler.GetUserID(HttpContext));

            return RedirectToAction("Index");
        }
    }
}