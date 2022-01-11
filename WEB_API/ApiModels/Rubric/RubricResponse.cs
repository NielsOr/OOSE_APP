using System.Collections.Generic;

namespace WEB_API.ApiModels
{
    public class RubricResponse
    {
        public string Code { get; set; }
        public string Naam { get; set; }
        public int Weging { get; set; }
        public double MinimaalOordeel { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<RubricCriteriumResponse> Beoordelingscriteria { get; set; }
    }
}
