
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("rubric_criterium")]
    public class RubricCriteriumEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RubricId { get; set; }

        [Required]
        public int Oordeel { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }
    }
}
