using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class BusinessType
    {
        public BusinessType()
        {
            UserProfileBusinessType = new HashSet<UserProfileBusinessType>();
            XBusinessToBusinessType = new HashSet<XBusinessToBusinessType>();
            XBusinessTypeToBusinessFeature = new HashSet<XBusinessTypeToBusinessFeature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserProfileBusinessType> UserProfileBusinessType { get; set; }
        public virtual ICollection<XBusinessToBusinessType> XBusinessToBusinessType { get; set; }
        public virtual ICollection<XBusinessTypeToBusinessFeature> XBusinessTypeToBusinessFeature { get; set; }
    }
}
