using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XUserToUserRole
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

        public virtual User User { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
