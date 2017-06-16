using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XBusinessToArea
    {
        public int BusinessId { get; set; }
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Business Business { get; set; }
    }
}
