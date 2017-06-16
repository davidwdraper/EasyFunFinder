using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class State
    {
        public State()
        {
            Area = new HashSet<Area>();
            Business = new HashSet<Business>();
        }

        public string Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Business> Business { get; set; }
    }
}
