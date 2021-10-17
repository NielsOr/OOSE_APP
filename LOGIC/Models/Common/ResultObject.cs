using System;

namespace LOGIC.Models
{
    public class ResultObject<T>
    {
        public ResultObject()
        {
            Success = false;
            UserMessage = string.Empty;
            InternalMessage = string.Empty;
            Exception = null;
        }
        public bool Success { get; set; }
        public string UserMessage { get; set; }
        internal string InternalMessage { get; set; } // As its internal the end user will not see it.
        internal Exception Exception { get; set; } // As its internal the end user will not see it.
        public T ResultSet { get; set; }
    }
}
