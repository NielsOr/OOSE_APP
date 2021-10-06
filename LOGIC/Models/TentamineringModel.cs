using System.Collections.Generic;

namespace LOGIC.Models
{
    public class TentamineringModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype  { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public EvlModel Evl { get; set; }
        public ICollection<LeeruitkomstModel> Leeruitkomsten { get; set; }
        public ICollection<BeoordelingsdimensieModel> Beoordelingsdimensies { get; set; }

    }
}