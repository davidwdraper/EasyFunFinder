using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class User
    {
        public User()
        {
            Image = new HashSet<Image>();
            UserProfile = new HashSet<UserProfile>();
            XEntityToImage = new HashSet<XEntityToImage>();
            XUserToEntertainer = new HashSet<XUserToEntertainer>();
            XUserToEvent = new HashSet<XUserToEvent>();
            XUserToPerson = new HashSet<XUserToPerson>();
            XUserToUserRole = new HashSet<XUserToUserRole>();
        }

        public int Id { get; set; }
        public Guid CookieId { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public Guid? PasswordSalt { get; set; }
        public bool IsBusinessUser { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual ICollection<XUserToEntertainer> XUserToEntertainer { get; set; }
        public virtual ICollection<XUserToEvent> XUserToEvent { get; set; }
        public virtual ICollection<XUserToPerson> XUserToPerson { get; set; }
        public virtual ICollection<XUserToUserRole> XUserToUserRole { get; set; }
    }
}
