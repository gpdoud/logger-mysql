using System;

namespace Logger.Models {
    
    public class Log {

        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Message { get; set; }
        
    }
}