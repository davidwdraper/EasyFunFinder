using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XEventToEventType
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
