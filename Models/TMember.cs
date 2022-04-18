using System;
using System.Collections.Generic;

namespace WebAppOceanShop.Models
{
    public partial class TMember
    {
        public int FId { get; set; }
        public string? FUserId { get; set; }
        public string? FPwd { get; set; }
        public string? FName { get; set; }
        public string? FEmail { get; set; }
    }
}
