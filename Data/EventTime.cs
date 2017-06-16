using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class EventTime
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }

        public virtual Event Event { get; set; }
    }
}
