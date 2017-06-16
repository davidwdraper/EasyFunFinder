using Microsoft.AspNetCore.Mvc;
using EasyFunFinder.Data;
using EasyFunFinder.DAL.Helpers;
using System;
using EasyFunFinder.DAL;
using EasyFunFinderWebAPI.Controllers;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyFunFinder.Controllers
{
    [Route("api/[controller]")] // api/user
    public class UserController : BaseController
    {
        protected string _className = "UserController";

        public UserController(EasyFunFinderContext dc) : base(dc) { }

        // PUT: api/user/validate/{cookie}/{email}
        [HttpPut, Route("validate/{cookie}/{email}")]
        public bool ValidatePassword([FromBody] string password, string cookie, string email)
        {
            try
            {
                Verify.HasContent("password", password);
                Verify.HasContent("cookie", cookie);
                Verify.HasContent("email", email);

                Guid gCookie;
                try
                {
                    gCookie = new Guid(cookie);
                }
                catch
                {
                    throw new Exception(string.Format("Could not convert cookie: {0} to a Guid", cookie));
                }

                var isVerified = new UserDAL(DC).ValidatePassword(gCookie, email, password);
                return isVerified;
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "ValidatePassword", ex);
                return false;
            }
        }

        // GET: api/user/{cookie}
        [HttpGet, Route("{cookie}")]
        public string GetUser(string cookie)
        {
            try
            {
                Verify.HasContent("cookie", cookie);

                Guid gCookie;
                try
                {
                    gCookie = new Guid(cookie);
                }
                catch
                {
                    throw new Exception(string.Format("Could not convert cookie: {0} to a Guid", cookie));
                }

                bool isNewUser;
                var user = new UserDAL(DC).GetUser(gCookie, out isNewUser);
                var userModel = new UserModel(user, isNewUser);
                var response = JsonConvert.SerializeObject(userModel);
                return response;
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "GetUser", ex);
                return "{}";
            }
        }

        // POST: api/user
        [HttpPost]
        public bool UpsertUser([FromBody] User user)
        {
            try
            {
                Verify.NotNull("user", user);

                new UserDAL(DC).UpsertUser(user);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "UpsertUser", ex);
                return false;
            }
        }

        // POST: api/user/profile
        [HttpPost, Route("profile")]
        public bool UpsertUserProfile([FromBody] UserProfile userProfile)
        {
            try
            {
                Verify.NotNull("userProfile", userProfile);

                new UserDAL(DC).UpsertUserProfile(userProfile);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(_className, "UpsertUserProfile", ex);
                return false;
            }
        }
    }
}