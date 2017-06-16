using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XBusinessToFeature
    {
        public int BusinessId { get; set; }
        public int BusinessFeatureId { get; set; }

        public virtual BusinessFeature BusinessFeature { get; set; }
        public virtual Business Business { get; set; }
    }
}
