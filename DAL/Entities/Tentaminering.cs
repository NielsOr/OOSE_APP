using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Tentaminering
    {
        public Int64 TentamineringID { get; set; } // PK
        public Int64 EVLID { get; set; } // FK
        public String Naam { get; set; }
        public String Code { get; set; }
        public String AanmeldingsType  { get; set; }
        public String Hulpmiddelen { get; set; }
        public Double Weging { get; set; }
        public Double MinimaalOordeel { get; set; }
        public String Tentamenvorm { get; set; }

        //RELATIES
        // many Tentaminering to many Leeruitkomsten
        public ICollection<Leeruitkomst> Leeruitkomsten { get; set; }
        // one Tentaminering to many Beoordelingsdimensies
        public ICollection<Beoordelingsdimensie> Beoordelingsdimensies { get; set; }

    }
}