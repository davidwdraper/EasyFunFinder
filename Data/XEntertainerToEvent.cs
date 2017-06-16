using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XEntertainerToEvent
    {
        public int EntertainerId { get; set; }
        public int EventId { get; set; }

        public virtual Entertainer Entertainer { get; set; }
        public virtual Event Event { get; set; }
    }
}
