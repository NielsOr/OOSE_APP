using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Leeruitkomst
    {
        public int Id { get; set; } // PK

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }


        //RELATIES
        // one EVL to many Leeruitkomst
        [Required]
        public Evl Evl { get; set; }

        // Many Leeruitkomst to many Tentamineringen
        public ICollection<Tentaminering> Tentamineringen { get; set; }

    }
}
