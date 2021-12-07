namespace LOGIC.Models.Historie
{
    public class LeeruitkomstRevisie : Revisie
    {
        public int LeeruitkomstId { get; set; }
        public int EvlId { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}
