using EasyFunFinder.DAL.Helpers;
using EasyFunFinder.Data;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace EasyFunFinder.DAL
{
    public class UserProfileDAL : BaseDAL
    {
        protected string _className = "UserProfileDAL";

        public UserProfileDAL(EasyFunFinderContext dc) : base(dc) { }

        public IEnumerable<UserProfile> GetProfiles(int userId)
        {
            try
            {
                Verify.HasPositiveInteger("userId", userId);

                var profiles = DC.UserProfile.Where(p => p.UserId == userId).ToList();

                return profiles;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}.UserProfileDAL.GetProfiles({}) - FAILED", _className, userId), ex);
            }
        }

        public UserProfile GetProfile(int userProfileId)
        {
            try
            {
                Verify.HasPositiveInteger("userProfileId", userProfileId);

                var profiles = DC.UserProfile.Where(p => p.Id == userProfileId).FirstOrDefault();
                return profiles;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}.UserProfileDAL.GetProfile({{1}}) - FAILED", _className, userProfileId), ex);
            }
        }

        public void UpdateLatLng(int profileId, float lat, float lng)
        {
            try
            {
                Verify.HasPositiveInteger("userProfileId", profileId);

                var profile = DC.UserProfile.Where(p => p.Id == profileId).FirstOrDefault();
                if (profile != null)
                {
                    profile.Lat = lat;
                    profile.Lng = lng;
                    DC.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}.UserProfileDAL.UpdateLatLng({1},{2},{3}) - FAILED", _className, profileId,lat,lng), ex);
            }
        }
    }
}