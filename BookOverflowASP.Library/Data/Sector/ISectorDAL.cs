using System.Collections.Generic;

namespace BookOverflowASP.Library.Data
{
    public interface ISectorDAL
    {
        List<SectorDTO> GetAll(int limit);
        SectorDTO GetById(int id);
        bool Remove(int sectorId, int userId);
        bool Save(SectorDTO sectorDto);
        bool Update(SectorDTO sectorDto);
    }
}