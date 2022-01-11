namespace LOGIC.Models
{
    public class TentamineringLeeruitkomst : RevisableObject
    {
        public int Id { get; set; }
        public string Beoordelingcriteria { get; set; }
        public int TentamineringId { get; set; }
        public int LeeruitkomstId { get; set; }
        public Leeruitkomst Leeruitkomst { get; set; }
    }
}