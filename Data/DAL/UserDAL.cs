using EasyFunFinder.DAL.Helpers;
using EasyFunFinder.Data;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EasyFunFinder.DAL
{
    public class UserDAL : BaseDAL
    {
        protected string _className = "UserDAL";

        public UserDAL(EasyFunFinderContext dc) : base(dc) { }

        public bool ValidatePassword(Guid cookieID, string eMail, string password)
        {
            try
            {
                Verify.NotNull("cookieID", cookieID);
                Verify.HasContent("eMail", eMail);
                Verify.HasContent("password", password);

                // Look for a pre-existing user via the user's email address which has a unique key constraint at the dB layer.
                User user = DC.User.Where(u => u.Email.ToLower() == eMail.ToLower()).FirstOrDefault();
    
                // Obviously the user must exist for a valid login
                if (user != null)
                {
                    // If there is no salt in the record, then there is no 
                    //  way that we can hash the password for comparison.
                    if (!user.PasswordSalt.HasValue)
                    {
                        // Add a salt if its missing (this should NEVER happen)
                        user.PasswordSalt = Guid.NewGuid();
                        UpsertUser(user);

                        return false;
                    }
                    var hash = GenerateSaltedHash(password, (Guid)user.PasswordSalt);
                    if (hash.SequenceEqual(user.PasswordHash.ToArray()))
                    {
                        // Check if the cookie value passed in is different than the one in the User's record.
                        // If so, we see if there is an existing User record (based on the old CookieID) that needs
                        // to be deleted.  We then update the existing record with the cookie value.
                        if (!cookieID.Equals(user.CookieId))
                        {
                            // Read via the old cookie value ...
                            var tmpUser = DC.User.Where(u => u.CookieId == cookieID).FirstOrDefault();
                            if (tmpUser != null)
                            {
                                DC.User.Remove(tmpUser);
                            }

                            // Update the existing record that we read via the email address
                            //  with the passed in cookieID
                            user.CookieId = cookieID;
                            DC.SaveChanges();
                        }

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.Login({0},{1}) - FAILED", cookieID, eMail), ex);
            }
        }

        /// <summary>
        /// Get or creates a new user (if one does not exist) for the supplied cookie
        /// </summary>
        /// <param name="cookieID"></param>
        /// <returns></returns>
        public User GetUser(Guid cookieID, out bool isNewUser)
        {
            try
            {
                isNewUser = false;
                User user = DC.User.Where(u => u.CookieId == cookieID)
                                .Include(p => p.UserProfile)
                                .Include(x => x.XEntityToImage)
                                .Include(x => x.XUserToEntertainer)
                                .Include(x => x.XUserToEvent)
                                .Include(x => x.XUserToPerson)
                                .Include(x => x.XUserToUserRole)
                                .FirstOrDefault();

                if (user == null)
                {
                    user = new User
                    {
                        CookieId = cookieID,
                        UniqueId = Guid.NewGuid(),
                        CreationDateTime = DateTime.UtcNow
                    };
                    isNewUser = true;
                    DC.User.Add(user);
                    DC.SaveChanges(); // save changes here to get the UserId back
                }
                // If the user does not have a profile, then we create a default profile.
                // If the user has exactly one profile, then we update it with the passed in lat/lng
                if (user.UserProfile == null || user.UserProfile.Count == 0)
                {
                    // TODO: call the profileDAL to do this...
                    user.UserProfile.Add(new UserProfile
                    {
                        UserId = user.Id,
                        ProfileName = "Default",
                        BusinessTypeId = 0,
                        DefaultProfile = true,
                        Radius = 10,
                        Lat = 0,
                        Lng = 0
                    });
                    DC.SaveChanges();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.GetUser({0}) - FAILED", cookieID), ex);
            }
        }

        public void UpsertUser(User userIn)
        {
            try
            {
                Verify.NotNull("userIn", userIn);

                // Is it a new User?
                if (userIn.Id == 0)
                {
                    // Then we insert it
                    DC.User.Add(userIn);
                }
                else
                {
                    var user = DC.User.Where(p => p.Id == userIn.Id).FirstOrDefault();
                    if (user == null)
                    {
                        // if we get here, something is wrong because the passed in object had an ID,
                        //  but its not found in the DB.  We try to insert it ...
                        DC.User.Add(userIn);
                    }
                    else
                    {
                        user.CookieId = userIn.CookieId;
                        user.FirstName = userIn.FirstName;
                        user.LastName = userIn.LastName;
                    }
                }

                DC.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.UpsertUser({0} - FAILED", userIn?.Id), ex);
            }
        }

        public void UpsertUserProfile(UserProfile userProfileIn)
        {
            try
            {
                Verify.NotNull("userProfile", userProfileIn);

                // Is it a new UserProfile object?
                if (userProfileIn.Id == 0)
                {
                    // Then we insert it
                    DC.UserProfile.Add(userProfileIn);
                }
                else
                {
                    var userProfile = DC.UserProfile.Where(p => p.Id == userProfileIn.Id).FirstOrDefault();
                    if (userProfile == null)
                    {
                        // if we get here, something is wrong because the passed in object had an ID,
                        //  but its not found in the DB.  We try to insert it ...
                        DC.UserProfile.Add(userProfileIn);
                    }
                    else
                    {
                        userProfile.ProfileName = userProfileIn.ProfileName;
                        userProfile.BusinessTypeId = userProfileIn.BusinessTypeId;
                        userProfile.Radius = userProfileIn.Radius;
                        userProfile.Lat = userProfileIn.Lat;
                        userProfile.Lng = userProfileIn.Lng;
                    }
                }

                DC.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.UpsertUserProfile({0} - FAILED", userProfileIn.Id), ex);
            }
        }

        public void SetAsDefaultProfile(int userID, int userProfileID)
        {
            try
            {
                Verify.IsTrue("userID", userID > 0);
                Verify.IsTrue("userProfileID", userProfileID > 0);

                bool bSaveChanges = false;

                // 1st get the current default profile
                var oldDefaultprofile = DC.UserProfile.Where(p => p.UserId == userID && p.DefaultProfile == true).FirstOrDefault();
                if (oldDefaultprofile != null)
                {
                    oldDefaultprofile.DefaultProfile = false;
                    bSaveChanges = true;
                }

                // 2nd, locate the passed in userProfileID and set it as the default
                // (we search on both keys just to be certain ...)
                var newDefaultProfile = DC.UserProfile.Where(p => p.UserId == userID && p.Id == userProfileID).FirstOrDefault();
                if (newDefaultProfile != null)
                {
                    newDefaultProfile.DefaultProfile = true;
                    bSaveChanges = true;
                }

                if (bSaveChanges)
                {
                    DC.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.SetDefaultProfile({0}) - FAILED", userID), ex);
            }
        }

        protected User NewUser(Guid cookieID, double lat, double lng)
        {
            try
            {
                Verify.IsTrue("cookieID", cookieID != null && cookieID != Guid.Empty);

                var user = new User
                {
                    CookieId = cookieID,
                    UniqueId = Guid.NewGuid(),
                    PasswordSalt = Guid.NewGuid(),
                    CreationDateTime = DateTime.UtcNow
                };

                // Every user can have many named profiles, we start them with one named 'Default' (user can change it)
                // BusinessTypeID == 1 is 'Entertainment', and that is our default type (user can change it)
                var userProfile = new UserProfile
                {
                    ProfileName = "Default",
                    BusinessTypeId = 1,
                    Radius = 10,
                    Lat = lat,
                    Lng = lng
                };

                using (DC.Database.BeginTransaction())
                {
                    // Submit User 1st to get the identity ID
                    DC.User.Add(user);
                    DC.SaveChanges();

                    userProfile.UserId = user.Id;
                    DC.UserProfile.Add(userProfile);
                    DC.SaveChanges();
                }

                // Fetch the user back from the DB so that the model includes the profile
                return DC.User.Where(p => p.Id == user.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("UserDAL.SetUserProfile({0} - FAILED", cookieID), ex);
            }
        }

        private static byte[] GenerateSaltedHash(string sPassword, Guid gSalt)
        {
            HashAlgorithm algorithm = SHA256.Create();
            byte[] password = Encoding.ASCII.GetBytes(sPassword);
            byte[] salt = gSalt.ToByteArray();

            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}