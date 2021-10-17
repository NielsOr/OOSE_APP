using System.Collections.Generic;

namespace LOGIC.Models
{
    public class TentamineringDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public EvlDto Evl { get; set; }
        public ICollection<LeeruitkomstDto> Leeruitkomsten { get; set; }
        public ICollection<BeoordelingsdimensieDto> Beoordelingsdimensies { get; set; }
    }
}