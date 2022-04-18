using System;
using System.Collections.Generic;

namespace WebAppOceanShop.Models
{
    public partial class TOrder
    {
        public int FId { get; set; }
        public string FOrderGuid { get; set; } = null!;
        public string FUserId { get; set; } = null!;
        public string? FReceiver { get; set; }
        public string? FEmail { get; set; }
        public string? FAddress { get; set; }
        public DateTime FDate { get; set; }
    }
}
