using System.Collections.Generic;

namespace LOGIC.Models
{
    public class Tentaminering
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public int EvlId { get; set; }
        public Evl Evl { get; set; }
        public List<Leeruitkomst> Leeruitkomsten { get; set; }
        public List<Beoordelingsdimensie> Beoordelingsdimensies { get; set; }
    }
}