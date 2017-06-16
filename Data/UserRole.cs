using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class UserRole
    {
        public UserRole()
        {
            XUserToUserRole = new HashSet<XUserToUserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<XUserToUserRole> XUserToUserRole { get; set; }
    }
}
