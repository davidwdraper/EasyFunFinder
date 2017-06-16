using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Person
    {
        public Person()
        {
            Business = new HashSet<Business>();
            Event = new HashSet<Event>();
            XEntertainerToPerson = new HashSet<XEntertainerToPerson>();
            XEntityToImage = new HashSet<XEntityToImage>();
            XUserToPerson = new HashSet<XUserToPerson>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Reknown { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual ICollection<Business> Business { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<XEntertainerToPerson> XEntertainerToPerson { get; set; }
        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual ICollection<XUserToPerson> XUserToPerson { get; set; }
    }
}
