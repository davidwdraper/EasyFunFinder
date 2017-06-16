using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Event
    {
        public Event()
        {
            EventTime = new HashSet<EventTime>();
            XEntertainerToEvent = new HashSet<XEntertainerToEvent>();
            XEntityToImage = new HashSet<XEntityToImage>();
            XEventToEventType = new HashSet<XEventToEventType>();
            XUserToEvent = new HashSet<XUserToEvent>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? BusinessId { get; set; }
        public int? ContactId { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual ICollection<EventTime> EventTime { get; set; }
        public virtual ICollection<XEntertainerToEvent> XEntertainerToEvent { get; set; }
        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual ICollection<XEventToEventType> XEventToEventType { get; set; }
        public virtual ICollection<XUserToEvent> XUserToEvent { get; set; }
        public virtual Business Business { get; set; }
        public virtual Person Contact { get; set; }
    }
}
