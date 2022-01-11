using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tentaminering_leeruitkomst")]
    public class TentamineringLeeruitkomstEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Beoordelingcriteria { get; set; }

        [Required]
        public int TentamineringId { get; set; }

        [Required]
        [ForeignKey("LeeruitkomstEntity")]
        public int LeeruitkomstId { get; set; }

        public LeeruitkomstEntity Leeruitkomst { get; set; }
    }
}