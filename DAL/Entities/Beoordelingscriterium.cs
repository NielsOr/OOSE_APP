using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Beoordelingscriterium
    {
        public int Id { get; set; } // PK

        [Required]
        public int Oordeel { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }


        // RELATIES
        // one Beoordelingsdimensie to many Beoordelingscriterium
        [Required]
        public Beoordelingsdimensie Beoordelingsdimensie { get; set; }
    }
}
