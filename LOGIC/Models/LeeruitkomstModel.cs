using System.Collections.Generic;

namespace LOGIC.Models
{
    public class LeeruitkomstModel
    {

        public int Id { get; set; } 
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public EvlModel Evl { get; set; }
        public ICollection<TentamineringModel> Tentamineringen { get; set; }

    }
}
