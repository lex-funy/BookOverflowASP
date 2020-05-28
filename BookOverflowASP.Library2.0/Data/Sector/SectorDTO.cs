using Logic = BookOverflowASP.Library.Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Library.Data
{
    public class SectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }

        public SectorDTO() { }

        public SectorDTO (Logic.Sector sector)
        {
            this.Id = sector.Id;
            this.Name = sector.Name;
        }

    }
}
