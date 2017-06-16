using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Entertainer
    {
        public Entertainer()
        {
            XEntertainerToEvent = new HashSet<XEntertainerToEvent>();
            XEntertainerToGenre = new HashSet<XEntertainerToGenre>();
            XEntertainerToPerson = new HashSet<XEntertainerToPerson>();
            XEntityToImage = new HashSet<XEntityToImage>();
            XUserToEntertainer = new HashSet<XUserToEntertainer>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EntertainerCategoryId { get; set; }
        public int? ContactId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual ICollection<XEntertainerToEvent> XEntertainerToEvent { get; set; }
        public virtual ICollection<XEntertainerToGenre> XEntertainerToGenre { get; set; }
        public virtual ICollection<XEntertainerToPerson> XEntertainerToPerson { get; set; }
        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual ICollection<XUserToEntertainer> XUserToEntertainer { get; set; }
        public virtual EntertainerCategory EntertainerCategory { get; set; }
    }
}
