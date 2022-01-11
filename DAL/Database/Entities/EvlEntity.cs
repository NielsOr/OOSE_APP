using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("evl")]
    public class EvlEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
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
        public string Beroepstaken { get; set; }

        [ForeignKey("EvlId")]
        public List<EindkwalificatieEntity> Eindkwalificaties { get; set; }

        [ForeignKey("EvlId")]
        public List<LeeruitkomstEntity> Leeruitkomsten { get; set; }

        [ForeignKey("EvlId")]
        public List<TentamineringEntity> Tentamineringen { get; set; }

        [ForeignKey("EvlId")]
        public List<EvlRevisieEntity> Historie { get; set; }
    }
}
