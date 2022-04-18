using System;
using System.Collections.Generic;

namespace WebAppOceanShop.Models
{
    public partial class TOrderDetail
    {
        public int FId { get; set; }
        public string FOrderGuid { get; set; } = null!;
        public string FUserId { get; set; } = null!;
        public string FPid { get; set; } = null!;
        public string FName { get; set; } = null!;
        public int FPrice { get; set; }
        public int FQty { get; set; }
        public decimal FDiscount { get; set; }
        public int FTotal { get; set; }
        public string FIsApproved { get; set; } = null!;
    }
}
