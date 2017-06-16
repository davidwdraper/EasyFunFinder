using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XUserToEntertainer
    {
        public int UserId { get; set; }
        public int EntertainerId { get; set; }

        public virtual Entertainer Entertainer { get; set; }
        public virtual User User { get; set; }
    }
}
