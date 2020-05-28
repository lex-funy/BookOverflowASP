using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Library.Logic
{
    public class SectorContainer : ISectorContainer
    {
        private readonly ISectorDAL _sectorDAL;
        private readonly IUserContainer _userContainer;

        public SectorContainer(ISectorDAL sectorDAL, IUserContainer userContainer)
        {
            this._sectorDAL = sectorDAL;
            this._userContainer = userContainer;
        }

        public List<Sector> GetAll(int limit = -1)
        {
            List<SectorDTO> sectorsDto = this._sectorDAL.GetAll(limit);

            List<Sector> sectors = new List<Sector>();
            foreach (SectorDTO sector in sectorsDto)
            {
                User deletedBy = this._userContainer.GetUserById(sector.DeletedBy);

                sectors.Add(new Sector(sector, deletedBy));
            }

            return sectors;
        }

        public Sector GetSectorById(int id)
        {
            SectorDTO sector = this._sectorDAL.GetById(id);
            User deletedBy = this._userContainer.GetUserById(sector.DeletedBy);

            return new Sector(sector, deletedBy);
        }

        public bool Save(Sector sector)
        {
            return this._sectorDAL.Save(new SectorDTO(sector));
        }

        public bool Update(Sector sector)
        {
            return this._sectorDAL.Update(new SectorDTO(sector));
        }

        public bool Remove(int sectorId, int userId)
        {
            return this._sectorDAL.Remove(sectorId, userId);
        }
    }
}
