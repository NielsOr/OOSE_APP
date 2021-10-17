using System.Collections.Generic;


namespace LOGIC.Models
{
    public class Beoordelingsdimensie
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Beschrijving { get; set; }
        public int TentamineringId { get; set; }
        public Tentaminering Tentaminering { get; set; }
        public List<Beoordelingscriterium> Beoordelingscriteria { get; set; }
    }
}
