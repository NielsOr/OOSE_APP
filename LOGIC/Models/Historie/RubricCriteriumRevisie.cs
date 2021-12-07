namespace LOGIC.Models.Historie
{
    public class RubricCriteriumRevisie : Revisie
    {
        public int RubricCriteriumId { get; set; }
        public int RubricId { get; set; }
        public int Oordeel { get; set; }
        public string Beschrijving { get; set; }
    }
}
