using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Evl
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }

        [Required]
        public double Studiepunten { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beroepstaken { get; set; } // class voor maken?

        [Required]
        [MaxLength(300)]
        public string Eindkwalificaties { get; set; } // class voor maken?


        // RELATIES
        // one EVL to many Leeruitkomsten
        public ICollection<Leeruitkomst> Leeruitkomsten { get; set; }
        // one EVL to many Tentamineringen
        public ICollection<Tentaminering> Tentamineringen { get; set; }
    }
}
