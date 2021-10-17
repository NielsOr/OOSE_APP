using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Tentaminering
    {
        public int Id { get; set; } // PK

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(300)]
        public string Aanmeldingstype { get; set; }

        [Required]
        [MaxLength(300)]
        public string Hulpmiddelen { get; set; }

        [Required]
        public int Weging { get; set; }

        [Required]
        [MaxLength(100)]
        public double MinimaalOordeel { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tentamenvorm { get; set; }


        //RELATIES
        // one EVL to many Tentamineringen
        [Required]
        public Evl Evl { get; set; }

        // many Tentaminering to many Leeruitkomsten
        public ICollection<Leeruitkomst> Leeruitkomsten { get; set; }

        // one Tentaminering to many Beoordelingsdimensies
        public ICollection<Beoordelingsdimensie> Beoordelingsdimensies { get; set; }
    }
}