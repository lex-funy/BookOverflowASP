using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
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

        public static bool Save(Sector sector)
        {
            return SectorDAL.Save(new SectorDTO(sector));
        }

        public static bool Update(Sector sector)
        {
            return SectorDAL.Update(new SectorDTO(sector));
        }

        public static bool Remove(int sectorId, int userId) 
        {
            return SectorDAL.Remove(sectorId, userId);
        }
    }
}
