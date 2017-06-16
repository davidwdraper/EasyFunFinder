using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XBusinessToProductBrand
    {
        public int BusinessId { get; set; }
        public int ProductBrandId { get; set; }

        public virtual Business Business { get; set; }
        public virtual ProductBrand ProductBrand { get; set; }
    }
}
