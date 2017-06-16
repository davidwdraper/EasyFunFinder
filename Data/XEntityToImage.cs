using System;
using System.Collections.Generic;

namespace EasyFunFinder.Data
{
    public partial class XEntityToImage
    {
        public Guid EntityId { get; set; }
        public Guid ImageId { get; set; }

        public virtual Business Entity { get; set; }
        public virtual Entertainer EntityNavigation { get; set; }
        public virtual Event Entity1 { get; set; }
        public virtual Person Entity2 { get; set; }
        public virtual User Entity3 { get; set; }
        public virtual Image Image { get; set; }
    }
}
