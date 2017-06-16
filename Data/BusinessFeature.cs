using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class BusinessFeature
    {
        public BusinessFeature()
        {
            XBusinessToFeature = new HashSet<XBusinessToFeature>();
            XBusinessTypeToBusinessFeature = new HashSet<XBusinessTypeToBusinessFeature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripiton { get; set; }

        public virtual ICollection<XBusinessToFeature> XBusinessToFeature { get; set; }
        public virtual ICollection<XBusinessTypeToBusinessFeature> XBusinessTypeToBusinessFeature { get; set; }
    }
}
