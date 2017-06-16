using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class PersonRole
    {
        public PersonRole()
        {
            XEntertainerToPerson = new HashSet<XEntertainerToPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<XEntertainerToPerson> XEntertainerToPerson { get; set; }
    }
}
