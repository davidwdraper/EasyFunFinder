using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class UserProfileBusinessType
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int BusinessTypeId { get; set; }

        public virtual BusinessType BusinessType { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
