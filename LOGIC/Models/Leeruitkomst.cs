using System.Collections.Generic;

namespace LOGIC.Models
{
    public class Leeruitkomst
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int EvlId { get; set; }
        public Evl Evl { get; set; }
        public List<Tentaminering> Tentamineringen { get; set; }

    }
}
