using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class UserEmailBlacklist
    {
        public string Email { get; set; }
        public DateTime BlackListedDateTime { get; set; }
    }
}
