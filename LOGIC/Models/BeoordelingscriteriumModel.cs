
namespace LOGIC.Models
{
    public class BeoordelingscriteriumModel
    {
        public int Id { get; set; } 
        public int Oordeel { get; set; }
        public string Beschrijving { get; set; }
        public BeoordelingsdimensieModel Beoordelingsdimensie { get; set; }
    }
}
