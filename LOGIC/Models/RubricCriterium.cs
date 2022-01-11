
namespace LOGIC.Models
{
    public class RubricCriterium : RevisableObject
    {
        public int Id { get; set; }
        public int RubricId { get; set; }
        public int Oordeel { get; set; }
        public string Beschrijving { get; set; }
    }
}
