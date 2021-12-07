using System.Collections.Generic;
using WEB_API.Contracts.RubricCriterium;

namespace WEB_API.Contracts.Rubric
{
    public class CreateRubricRequest
    {
        public int TentamineringId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public double Studiepunten { get; set; }
        public string Beroepstaken { get; set; }
        public string Eindkwalificaties { get; set; }
        public IEnumerable<RubricCriteriumContract> Beoordelingscriteria { get; set; }
    }
}
