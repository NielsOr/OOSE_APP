namespace LOGIC.Models
{
    public class Leeruitkomst : RevisableObject
    {
        public int Id { get; set; }
        public int EvlId { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
    }
}
