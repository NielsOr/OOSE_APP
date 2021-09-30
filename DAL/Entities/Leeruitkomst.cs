using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Leeruitkomst
    {
        public Int64 LeeruitkomstID { get; set; } // PK
        public Int64 EVLID { get; set; } // FK
        public String Naam { get; set; }
        public String Beschrijving { get; set; }

        //RELATIES
        // one EVL to many Leeruitkomst
        public EVL EVL { get; set; }
        // Many to many
        public ICollection<Tentaminering> Tentamineringen { get; set; }

    }
}
