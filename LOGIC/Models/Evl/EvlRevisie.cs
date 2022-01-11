
using System;

namespace LOGIC.Models
{
    public class EvlRevisie : Evl
    {
        public int EvlId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
