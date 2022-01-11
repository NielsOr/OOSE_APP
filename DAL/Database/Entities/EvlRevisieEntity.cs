using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("evl")]
    public class EvlRevisieEntity : EvlEntity
    {
        public int EvlId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ModifiedBy { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
