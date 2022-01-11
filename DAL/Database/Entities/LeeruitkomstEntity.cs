using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("leeruitkomst")]
    public class LeeruitkomstEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EvlId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beschrijving { get; set; }
    }
}
