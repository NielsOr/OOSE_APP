using System;

namespace LOGIC.Models.Historie
{
    public class Revisie
    {
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
