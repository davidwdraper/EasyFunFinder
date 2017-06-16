using System;

namespace EasyFunFinder.Data.Logger
{
    public partial class LogEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public int? TraceType { get; set; }
        public string ModuleName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string ExceptionText { get; set; }
        public DateTime EntryDateTime { get; set; }
    }
}
