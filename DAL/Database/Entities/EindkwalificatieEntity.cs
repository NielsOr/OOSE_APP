using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("eindkwalificatie")]
    public class EindkwalificatieEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EvlId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }
    }
}
