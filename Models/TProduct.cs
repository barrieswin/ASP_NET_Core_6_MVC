using System;
using System.Collections.Generic;

namespace WebAppOceanShop.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        public int FCategory { get; set; }
        public string FPid { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string FDescription { get; set; } = null!;
        public int FPrice { get; set; }
        public string FImagePath { get; set; } = null!;
        public bool FIsActiveFlag { get; set; }

        public virtual TCategory FCategoryNavigation { get; set; } = null!;
    }
}
