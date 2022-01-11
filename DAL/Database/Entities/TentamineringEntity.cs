using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tentaminering")]
    public class TentamineringEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EvlId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Aanmeldingstype { get; set; }

        [Required]
        [MaxLength(100)]
        public string Hulpmiddelen { get; set; }

        [Required]
        public int Weging { get; set; }

        [Required]
        public double MinimaalOordeel { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tentamenvorm { get; set; }

        [ForeignKey("TentamineringId")]
        public List<TentamineringLeeruitkomstEntity> Leeruitkomsten { get; set; }

        [ForeignKey("TentamineringId")]
        public List<RubricEntity> Rubrics { get; set; }
    }
}