using System.Collections.Generic;

namespace WEB_API.ApiModels
{
    public class UpdateTentamineringRequest
    {
        public string Naam { get; set; }
        public string Code { get; set; }
        public string Aanmeldingstype { get; set; }
        public string Hulpmiddelen { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Tentamenvorm { get; set; }
        public IEnumerable<TentamineringLeeruitkomstRequest> Leeruitkomsten { get; set; }
    }
}