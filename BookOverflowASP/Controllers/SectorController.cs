using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookOverflowASP.Models;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Controllers
{
    public class SectorController : Controller
    {
        public IActionResult Index()
        {
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(SectorModel sectorModel)
        {
            // TODO: Store the sector in the database
            SectorContainer.Save(sectorModel);

            // FIXME: Redirect
            return RedirectToAction("Index");
        }
    }
}