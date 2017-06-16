using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XBusinessTypeToBusinessFeature
    {
        public int BusinessTypeId { get; set; }
        public int BusinessFeatureId { get; set; }

        public virtual BusinessFeature BusinessFeature { get; set; }
        public virtual BusinessType BusinessType { get; set; }
    }
}
