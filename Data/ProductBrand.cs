using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class ProductBrand
    {
        public ProductBrand()
        {
            XBusinessToProductBrand = new HashSet<XBusinessToProductBrand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<XBusinessToProductBrand> XBusinessToProductBrand { get; set; }
    }
}
