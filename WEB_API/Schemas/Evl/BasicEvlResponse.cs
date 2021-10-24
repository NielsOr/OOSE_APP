using System.Collections.Generic;
using WEB_API.Schemas.Leeruitkomst;

namespace WEB_API.Schemas.Evl
{
    public class EvlResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public string Eindkwalificaties { get; set; }
        public IEnumerable<LeeruitkomstResponse> Leeruitkomsten { get; set; }
    }
}