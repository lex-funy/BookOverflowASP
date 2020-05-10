using System;
using BookOverflowASP.Data;
using BookOverflowASP.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public Sector() { }

        public Sector(SectorDTO sectorDTO)
        {
            this.Id = sectorDTO.Id;
            this.Name = sectorDTO.Name;
            this.CreatedAt = sectorDTO.CreatedAt;
            this.DeletedAt = sectorDTO.DeletedAt;
        }

        public Sector(SectorModel sectorModel) 
        {
            throw new NotImplementedException();
        }
    }
}
