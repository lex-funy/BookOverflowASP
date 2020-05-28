using Logic = BookOverflowASP.Library.Logic;

using BookOverflowASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP
{
    public class SectorConverter
    {
        public Logic.Sector ConvertSectorModelToSector(SectorModel sectorModel)
        {
            Logic.Sector sector = new Logic.Sector();

            sector.Id = sectorModel.Id;
            sector.Name = sectorModel.Name;

            return sector;
        }

        public SectorModel ConvertCoureToSectorModel(Logic.Sector sector)
        {
            SectorModel sectorModel = new SectorModel();

            sectorModel.Id = sector.Id;
            sectorModel.Name = sector.Name;

            return sectorModel;
        }
    }
}
