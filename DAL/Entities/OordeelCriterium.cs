using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OordeelCriterium
    {
        public Int64 OordeelCriteriumID { get; set; } // PK
        public Int64 BeoordelingsdimensieID { get; set; } // FK
        public int Oordeel { get; set; }
        public String Beschrijving { get; set; }

        // RELATIES
        // one Beoordelingsdimensie to many OordeelCriteria
        public Beoordelingsdimensie Beoordelingsdimensie { get; set; }
    }
}
