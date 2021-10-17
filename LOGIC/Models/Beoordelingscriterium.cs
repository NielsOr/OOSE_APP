
namespace LOGIC.Models
{
    public class Beoordelingscriterium
    {
        public int Id { get; set; }
        public int Oordeel { get; set; }
        public string Beschrijving { get; set; }
        public int BeoordelingsdimensieId { get; set; }
        public Beoordelingsdimensie Beoordelingsdimensie { get; set; }
    }
}
