using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EVL
    {
        public Int64 EVLID { get; set; }
        public String Code { get; set; }
        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public String Beroepstaken { get; set; }
        public String Eindkwalificaties { get; set; }
        public Double Studiepunten { get; set; }

        // RELATIES
        // one EVL to many Leeruitkomsten
        public ICollection<Leeruitkomst> Leeruitkomsten { get; set; }
        // one EVL to many Tentamineringen
        public ICollection<Tentaminering> Tentamineringen { get; set; }
    }
}
