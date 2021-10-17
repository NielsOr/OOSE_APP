using System.Collections.Generic;

namespace LOGIC.Models
{
    public class LeeruitkomstDto
    {

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public EvlDto Evl { get; set; }
        public ICollection<TentamineringDto> Tentamineringen { get; set; }
    }
}
