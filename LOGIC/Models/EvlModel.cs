using System.Collections.Generic;

namespace LOGIC.Models
{
    public class EvlModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; } // class voor maken?
        public string Eindkwalificaties { get; set; } // class voor maken?
        public ICollection<LeeruitkomstModel> Leeruitkomsten { get; set; }
        public ICollection<TentamineringModel> Tentamineringen { get; set; }
    }
}
