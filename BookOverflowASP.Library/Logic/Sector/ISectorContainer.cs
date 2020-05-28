using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public interface ISectorContainer
    {
        List<Sector> GetAll(int limit = -1);
        Sector GetSectorById(int id);
        bool Remove(int sectorId, int userId);
        bool Save(Sector sector);
        bool Update(Sector sector);
    }
}