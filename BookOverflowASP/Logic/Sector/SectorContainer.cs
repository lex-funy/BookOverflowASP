using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Data;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Logic
{
    public class SectorContainer
    {
        public static List<Sector> GetAll(int limit = -1)
        {
            List<SectorDTO> sectorsDto = SectorDAL.GetAll(limit);

            List<Sector> sectors = new List<Sector>();
            foreach (SectorDTO sector in sectorsDto) 
            {
                sectors.Add(new Sector(sector));
            }

            return sectors;
        }

        public static Sector GetSectorById(int id)
        {
            return new Sector(SectorDAL.GetById(id));
        }

        public static bool Save(SectorModel sectorModel)
        {
            return SectorDAL.Save(new SectorDTO(sectorModel));
        }

        public static bool Update(SectorModel sectorModel)
        {
            return SectorDAL.Update(new SectorDTO(sectorModel));
        }

        public static bool Remove(int sectorId, int userId) 
        {
            return SectorDAL.Remove(sectorId, userId);
        }
    }
}
