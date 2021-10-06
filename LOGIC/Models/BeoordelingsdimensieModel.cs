using System.Collections.Generic;


namespace LOGIC.Models
{
    public class BeoordelingsdimensieModel
    {
        public int Id { get; set; } 
        public string Code { get; set; }
        public string Naam { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Beschrijving { get; set; }
        public TentamineringModel Tentaminering { get; set; }
        public ICollection<BeoordelingscriteriumModel> Beoordelingscriteria { get; set; }
    }
}
