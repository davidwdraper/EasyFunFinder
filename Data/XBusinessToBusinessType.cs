using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XBusinessToBusinessType
    {
        public int BusinessId { get; set; }
        public int BusinessTypeId { get; set; }

        public virtual Business Business { get; set; }
        public virtual BusinessType BusinessNavigation { get; set; }
    }
}
