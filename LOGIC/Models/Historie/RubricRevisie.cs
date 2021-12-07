using System.Collections.Generic;

namespace LOGIC.Models.Historie
{
    public class RubricRevisie : Revisie
    {
        public int RubricId { get; set; }
        public int TentamineringId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Beschrijving { get; set; }
        public List<RubricCriteriumRevisie> Beoordelingscriteria { get; set; }
    }
}
