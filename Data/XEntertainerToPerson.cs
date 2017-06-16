using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XEntertainerToPerson
    {
        public int EntertainerId { get; set; }
        public int PersonId { get; set; }
        public int PersonRoleId { get; set; }

        public virtual Entertainer Entertainer { get; set; }
        public virtual Person Person { get; set; }
        public virtual PersonRole PersonRole { get; set; }
    }
}
