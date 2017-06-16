﻿using Microsoft.AspNetCore.Mvc;
using EasyFunFinder.Data;
using EasyFunFinder.DAL.Helpers;
using System;
using EasyFunFinder.DAL;
using EasyFunFinderWebAPI.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyFunFinder.Controllers
{
    [Route("api/[controller]")] // api/userprofile
    public class UserProfileController : BaseController
    {
        protected string _className = "UserProfileController";

        public UserProfileController(EasyFunFinderContext dc) : base(dc) { }


        // Get all profiles for a user
        // GET: api/userprofile/user/{userId}
        [HttpGet, Route("user/{userId:int}")]
        public string GetUserProfiles(int userId)
        {
            try
            {
                Verify.HasPositiveInteger("userId", userId);

                var userProfiles = new UserProfileDAL(DC).GetProfiles(userId);

                // The models generated by Entityframework have cylical references that don't jsonize,
                //  we therefore have to build our model for responding...
                var userProfileModels = new List<UserProfileModel>();
                foreach(var profile in userProfiles)
                {
                    userProfileModels.Add(new UserProfileModel(profile));
                }
                return JsonConvert.SerializeObject(userProfileModels);
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "GetUserProfiles", ex);
                return "{}";
            }
        }

        // Get a specific profile
        // GET: api/userprofile/{profileId}
        [HttpGet, Route("{userProfileId:int}")]
        public string GetUserProfile(int userProfileId)
        {
            try
            {
                Verify.HasPositiveInteger("userProfileId", userProfileId);

                var userProfile = new UserProfileDAL(DC).GetProfile(userProfileId);
                var userProfileModel = new UserProfileModel(userProfile);
                return JsonConvert.SerializeObject(userProfileModel);
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "GetUserProfile", ex);
                return "{}";
            }
        }

        [HttpPost, Route("latlng/{profileId:int}/{lat:float}/{lng:float}")]
        public void UpdateLatLng(int profileId, float lat, float lng)
        {
            try
            {
                Verify.HasPositiveInteger("profileId", profileId);

                new UserProfileDAL(DC).UpdateLatLng(profileId, lat, lng);
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "UpdateLatLng", ex);
            }
        }
    }
}