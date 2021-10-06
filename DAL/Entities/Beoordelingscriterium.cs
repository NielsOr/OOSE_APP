using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
