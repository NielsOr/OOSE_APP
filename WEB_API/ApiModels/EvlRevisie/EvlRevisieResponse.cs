using System.Collections.Generic;

namespace WEB_API.ApiModels
{
    public class EvlRevisieResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public IEnumerable<EindkwalificatieResponse> Eindkwalificaties { get; set; }
        public IEnumerable<TentamineringResponse> Tentamineringen { get; set; }
        public IEnumerable<LeeruitkomstResponse> Leeruitkomsten { get; set; }
    }
}