using System.Collections.Generic;

namespace LOGIC.Models.Historie
{
    public class TentamineringRevisie : Revisie
    {
        public int TentamineringId { get; set; }
        public int EvlId { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public List<TentamineringLeeruitkomstRevisie> Leeruitkomsten { get; set; }
        public List<RubricRevisie> Rubrics { get; set; }
    }
}
