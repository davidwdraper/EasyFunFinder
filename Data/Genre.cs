using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Genre
    {
        public Genre()
        {
            XEntertainerToGenre = new HashSet<XEntertainerToGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<XEntertainerToGenre> XEntertainerToGenre { get; set; }
    }
}
