using BookOverflowASP.Library.Logic;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookOverflowASP.Controllers
{
    public class SectorController : Controller
    {
        private readonly ISessionHandler _sessionHandler;
        private readonly IMiddleware _middleware;

        public SectorController(ISessionHandler sessionHandler, IMiddleware middleware)
        {
            this._sessionHandler = sessionHandler;
            this._middleware = middleware;
        }
        public IActionResult Index()
        {
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
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
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SectorModel sectorModel)
        {
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            SectorConverter sectorConverter = new SectorConverter();
            SectorContainer.Save(sectorConverter.ConvertSectorModelToSector(sectorModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
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
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext)) 
                return RedirectToAction("Login", "User");

            SectorConverter sectorConverter = new SectorConverter();
            if (SectorContainer.Update(sectorConverter.ConvertSectorModelToSector(sectorModel))) 
                return RedirectToAction("Index");
            return RedirectToAction("Edit", sectorModel.Id);
        }

        public IActionResult Remove(int id) 
        {
            if (!this._middleware.CheckUserPermission(PermissionType.Admin, HttpContext))     
                return RedirectToAction("Login", "User");

            // TODO: Add validation message
            SectorContainer.Remove(id, this._sessionHandler.GetUserID(HttpContext));

            return RedirectToAction("Index");
        }
    }
}