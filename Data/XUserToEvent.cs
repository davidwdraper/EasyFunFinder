using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XUserToEvent
    {
        public int UserId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
