using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class Image
    {
        public Image()
        {
            XEntityToImage = new HashSet<XEntityToImage>();
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Bytes { get; set; }
        public int AddedByUserId { get; set; }
        public DateTime DateTimeAdded { get; set; }

        public virtual ICollection<XEntityToImage> XEntityToImage { get; set; }
        public virtual User AddedByUser { get; set; }
    }
}
