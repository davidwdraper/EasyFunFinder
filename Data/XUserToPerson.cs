using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XUserToPerson
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual User User { get; set; }
    }
}
