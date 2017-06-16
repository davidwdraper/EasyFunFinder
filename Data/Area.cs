using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Area
    {
        public Area()
        {
            XBusinessToArea = new HashSet<XBusinessToArea>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pcode { get; set; }
        public string County { get; set; }
        public string CountryCode { get; set; }
        public string GooglePlaceId { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }

        public virtual ICollection<XBusinessToArea> XBusinessToArea { get; set; }
        public virtual State StateNavigation { get; set; }
    }
}
