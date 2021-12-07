namespace LOGIC.Models.Historie
{
    public class TentamineringLeeruitkomstRevisie : Revisie
    {
        public int TentamineringLeeruitkomstId { get; set; }
        public string Beoordelingcriteria { get; set; }
        public int TentamineringId { get; set; }
        public int LeeruitkomstId { get; set; }
        public LeeruitkomstRevisie Leeruitkomst { get; set; }
    }
}
