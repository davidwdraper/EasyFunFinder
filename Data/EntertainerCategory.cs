using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class EntertainerCategory
    {
        public EntertainerCategory()
        {
            Entertainer = new HashSet<Entertainer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Entertainer> Entertainer { get; set; }
    }
}
