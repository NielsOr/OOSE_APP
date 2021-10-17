
namespace LOGIC.Models
{
    public class BeoordelingscriteriumDto
    {
        public int Id { get; set; }
        public int Oordeel { get; set; }
        public string Beschrijving { get; set; }
        public BeoordelingsdimensieDto Beoordelingsdimensie { get; set; }
    }
}
