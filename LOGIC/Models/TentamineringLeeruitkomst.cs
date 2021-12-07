using System.Collections.Generic;

namespace LOGIC.Models
{
    public class TentamineringLeeruitkomst
    {
        public int Id { get; set; }
        public string Beoordelingcriteria { get; set; }
        public int TentamineringId { get; set; }
        public int LeeruitkomstId { get; set; }
        public Leeruitkomst Leeruitkomst { get; set; }
    }
}