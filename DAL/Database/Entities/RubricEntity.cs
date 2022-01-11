using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("rubrics")]
    public class RubricEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TentamineringId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        public int Weging { get; set; }

        [Required]
        public double MinimaalOordeel { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }

        [ForeignKey("RubricId")]
        public List<RubricCriteriumEntity> Beoordelingscriteria { get; set; }

    }
}
