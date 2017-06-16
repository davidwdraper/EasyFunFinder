using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class EventType
    {
        public EventType()
        {
            XEventToEventType = new HashSet<XEventToEventType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<XEventToEventType> XEventToEventType { get; set; }
    }
}
