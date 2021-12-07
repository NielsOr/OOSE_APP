
using System.Collections.Generic;

namespace LOGIC.Models.Historie
{
    public class EvlRevisie : Revisie
    {
        public int EvlId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public string Eindkwalificaties { get; set; }
        public List<LeeruitkomstRevisie> Leeruitkomsten { get; set; }
        public List<TentamineringRevisie> Tentamineringen { get; set; }
    }
}
