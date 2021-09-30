using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Beoordelingsdimensie
    {
        public String BeoordelingsdimensieID { get; set; } // PK
        public Int64 TentamineringID { get; set; } // FK
        public String Code { get; set; }
        public String Naam { get; set; }
        public Double Weging { get; set; }
        public Double MinimaalOordeel { get; set; }
        public String Beschrijving { get; set; }

        //RELATIES
        // one Tentaminering to many Beoordelingsdimensies
        public ICollection<OordeelCriterium> OordeelCriteria { get; set; }
    }
}
