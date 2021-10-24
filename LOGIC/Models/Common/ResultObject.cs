using System;

namespace LOGIC.Models
{
    public class ResultObject<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        internal Exception Exception { get; set; } // As it's internal the end user will not see it. For logging purposes.
        public T ResultSet { get; set; }
    }
}
