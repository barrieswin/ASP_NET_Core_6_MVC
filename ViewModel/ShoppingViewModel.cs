using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using WebAppOceanShop.Models;

namespace WebAppOceanShop.ViewModel
{

    //注意: 還沒編輯完成
    //
    //
    //
    //
    //


    public class ShoppingViewModel
    {
        [DisplayName("產品流水編號")]
        public int FId { get; set; }

        [DisplayName("產品類別")]
        public int FCategory { get; set; }

        [DisplayName("產品編號")]
        [Required(ErrorMessage = "產品名稱為必要輸入。")]
        [StringLength(50, ErrorMessage = "產品名稱長度不可以超過50")]
        public string FPid { get; set; } = null!;

        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "產品名稱為必要輸入。")]
        [StringLength(50, ErrorMessage = "產品名稱長度不可以超過50")]
        public string FName { get; set; } = null!;

        [DisplayName("產品說明")]
        [Required(ErrorMessage = "產品說明為必要輸入。")]
        [StringLength(250, ErrorMessage = "產品名稱長度不可以超過250")]
        public string FDescription { get; set; } = null!;

        [DisplayName("產品價格")]
        [Required(ErrorMessage = "產品價格為必要輸入。")]
        [Range(0, 99999, ErrorMessage = "價格只能是 0 .. 99999。")]
        public int FPrice { get; set; }

        [DisplayName("產品圖片路徑")]
        [Required(ErrorMessage = "圖片為必要輸入。")]
        public string FImagePath { get; set; } = null!;

        [DisplayName("產品供應狀態")]
        public bool FIsActiveFlag { get; set; } = false;
    }
}
