using System;

namespace LOGIC.Models
{
    // WILL BE USED AS EVERY RESULT OBJECT FROM OUR Handler METHODS
    public class ResultObject<T>
    {
        public bool Success { get; set; }
        public string UserMessage { get; set; }
        internal string InternalMessage { get; set; } // As its internal the end user will not see it.
        internal Exception Exception { get; set; } // As its internal the end user will not see it.
        public T ResultSet { get; set; }
    }
}
