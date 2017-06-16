using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserProfileBusinessType = new HashSet<UserProfileBusinessType>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfileName { get; set; }
        public int? BusinessTypeId { get; set; }
        public bool DefaultProfile { get; set; }
        public int Radius { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }

        public virtual ICollection<UserProfileBusinessType> UserProfileBusinessType { get; set; }
        public virtual User User { get; set; }
    }
}
