using System;
using System.Linq;

namespace EasyFunFinder.Data
{
    public class UserModel
    {
        private User _user;

        public UserModel(User user, bool isNewUser)
        {
            _user = user;
            Id = user.Id;
            CookieId = user.CookieId;
            UniqueId = user.UniqueId;
            FirstName = user.FirstName;
            Email = user.Email;
            IsBusinessUser = user.IsBusinessUser;
            LastLoginDateTime = user.LastLoginDateTime;
            CreationDateTime = user.CreationDateTime;
        }

        public bool IsNewUser { get; set; }
        public int Id { get; set; }
        public Guid CookieId { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsBusinessUser { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }

        public String[] ImageIds => (from i in _user.XEntityToImage select i.ImageId.ToString()).ToArray();

        public int[] UserProfileIds => (from p in _user.UserProfile select p.Id).ToArray();

        // The entertainers that the user is following
        public int[] EntertainerIds => (from e in _user.XUserToEntertainer select e.EntertainerId).ToArray();

        // The events the user is following
        public int[] EventIds => (from e in _user.XUserToEvent select e.EventId).ToArray();

        // The persons that the user is following
        public int[] PersonIds => (from p in _user.XUserToPerson select p.PersonId).ToArray();

        public int[] RoleIds => (from r in _user.XUserToUserRole select r.UserRoleId).ToArray();
    }
}
