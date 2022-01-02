using System;

namespace LOGIC.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
