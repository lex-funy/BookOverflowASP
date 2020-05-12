using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class SectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public SectorDTO() { }

        public SectorDTO (SectorModel sectorModel)
        {
            this.Id = sectorModel.Id;
            this.Name = sectorModel.Name;
        }

    }
}
