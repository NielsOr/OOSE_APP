using System.Collections.Generic;
using WEB_API.Contracts.TentamineringLeeruitkomst;

namespace WEB_API.Contracts.Tentaminering
{
    public class CreateTentamineringRequest
    {
        public int EvlId { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public string Tentamenmoment { get; set; }
        public IEnumerable<TentamineringLeeruitkomstRequest> Leeruitkomsten { get; set; }
    }
}