using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Beoordelingsdimensie
    {
        public int Id { get; set; } // PK

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        public int Weging { get; set; }

        public double MinimaalOordeel { get; set; }

        [MaxLength(300)]
        public string Beschrijving { get; set; }


        //RELATIES
        // one Tentaminering to many Beoordelingsdimensies
        [Required]
        public Tentaminering Tentaminering { get; set; }
        // one Beoordelingsdimensie to many Beoordelingscriteria
        public ICollection<Beoordelingscriterium> Beoordelingscriteria { get; set; }
    }
}
