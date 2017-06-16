using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class UserProfileModel
    {
        public UserProfileModel(UserProfile userProfile)
        {
            Id = userProfile.Id;
            UserId = userProfile.UserId;
            ProfileName = userProfile.ProfileName;
            BusinessTypeId = userProfile.BusinessTypeId;
            DefaultProfile = userProfile.DefaultProfile;
            Radius = userProfile.Radius;
            Lat = userProfile.Lat;
            Lng = userProfile.Lng;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfileName { get; set; }
        public int? BusinessTypeId { get; set; }
        public bool DefaultProfile { get; set; }
        public int Radius { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
