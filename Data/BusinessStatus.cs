using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class BusinessStatus
    {
        public BusinessStatus()
        {
            Business = new HashSet<Business>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
