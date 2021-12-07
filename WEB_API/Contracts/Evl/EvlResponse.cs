using System.Collections.Generic;
using WEB_API.Contracts.Leeruitkomst;
using WEB_API.Contracts.Tentaminering;

namespace WEB_API.Contracts.Evl
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
        public IEnumerable<TentamineringResponse> Tentamineringen { get; set; }
        public IEnumerable<LeeruitkomstResponse> Leeruitkomsten { get; set; }
    }
}