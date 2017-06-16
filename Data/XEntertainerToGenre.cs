using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XEntertainerToGenre
    {
        public int EntertainerId { get; set; }
        public int GenreId { get; set; }

        public virtual Entertainer Entertainer { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
