using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Business
    {
        public Business()
        {
            Event = new HashSet<Event>();
            XBusinessToArea = new HashSet<XBusinessToArea>();
            XBusinessToBusinessType = new HashSet<XBusinessToBusinessType>();
            XBusinessToFeature = new HashSet<XBusinessToFeature>();
            XBusinessToProductBrand = new HashSet<XBusinessToProductBrand>();
            XEntityToImage = new HashSet<XEntityToImage>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Guid UniqueId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int? ContactId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pcode { get; set; }
        public string County { get; set; }
        public string CountryCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string WebsiteUrl { get; set; }
        public string GooglePlaceId { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public DateTime CreationDateTime { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<XBusinessToArea> XBusinessToArea { get; set; }
        public virtual ICollection<XBusinessToBusinessType> XBusinessToBusinessType { get; set; }
        public virtual ICollection<XBusinessToFeature> XBusinessToFeature { get; set; }
        public virtual ICollection<XBusinessToProductBrand> XBusinessToProductBrand { get; set; }
        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual Person Contact { get; set; }
        public virtual State StateNavigation { get; set; }
        public virtual BusinessStatus StatusNavigation { get; set; }
    }
}
