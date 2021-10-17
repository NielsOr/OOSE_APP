using System.Collections.Generic;


namespace LOGIC.Models
{
    public class BeoordelingsdimensieDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Beschrijving { get; set; }
        public TentamineringDto Tentaminering { get; set; }
        public ICollection<BeoordelingscriteriumDto> Beoordelingscriteria { get; set; }
    }
}
