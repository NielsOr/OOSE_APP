using System;

namespace LOGIC.Models
{
    public class ResultObject<T>
    {
        public bool Success { get; set; }
        public string UserMessage { get; set; }
        internal string InternalMessage { get; set; } // As it's internal the end user will not see it.
        internal Exception Exception { get; set; } // As it's internal the end user will not see it.
        public T ResultSet { get; set; }
    }
}
