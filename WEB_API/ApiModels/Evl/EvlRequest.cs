using System.Collections.Generic;

namespace WEB_API.ApiModels
{
    public class EvlRequest
    {
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public IEnumerable<EindkwalificatieRequest> Eindkwalificaties { get; set; }
    }
}