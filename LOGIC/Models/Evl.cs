using System.Collections.Generic;

namespace LOGIC.Models
{
    public class Evl
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public string Eindkwalificaties { get; set; }
        public List<Leeruitkomst> Leeruitkomsten { get; set; }
        public List<Tentaminering> Tentamineringen { get; set; }
    }
}
