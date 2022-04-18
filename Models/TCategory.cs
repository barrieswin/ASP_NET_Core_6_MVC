using System;
using System.Collections.Generic;

namespace WebAppOceanShop.Models
{
    public partial class TCategory
    {
        public TCategory()
        {
            TProducts = new HashSet<TProduct>();
        }

        public int FId { get; set; }
        public int FCategory { get; set; }
        public string FCategoryName { get; set; } = null!;

        public virtual ICollection<TProduct> TProducts { get; set; }
    }
}
