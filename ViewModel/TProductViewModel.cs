using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using WebAppOceanShop.Models;

namespace WebAppOceanShop.ViewModel
{
    public class TProductViewModel
    {
        [DisplayName("產品流水編號")]
        public int FId { get; set; }


        [DisplayName("產品類別")]
        public int FCategory { get; set; }


        [DisplayName("產品編號")]
        [Required(ErrorMessage = "產品名稱為必要輸入。")]
        [StringLength(25, ErrorMessage = "產品名稱長度不可以超過25")]
        public string FPid { get; set; } = null!;


        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "產品名稱為必要輸入。")]
        [StringLength(25, ErrorMessage = "產品名稱長度不可以超過25")]
        public string FName { get; set; } = null!;


        [DisplayName("產品說明")]
        [Required(ErrorMessage = "產品說明為必要輸入。")]
        [StringLength(250, ErrorMessage = "產品名稱長度不可以超過250")]
        public string FDescription { get; set; } = null!;


        [DisplayName("產品價格")]
        [Required(ErrorMessage = "產品價格為必要輸入。")]
        [Range(0, 99999, ErrorMessage = "價格只能是 0 .. 99999。")]
        public int FPrice { get; set; }


        [DisplayName("產品圖片")]
        [Required(ErrorMessage = "圖片為必要輸入。")]
        public IFormFile FImage { get; set; } = null!;


        [DisplayName("產品圖片路徑")]
        public string FImagePath { get; set; } = null!;
       //public HttpPostedFileBase FImagePath { get; set; }  //.net


        [DisplayName("產品供應狀態")]
        public bool FIsActiveFlag { get; set; } = false;

        public virtual TCategory FCategoryNavigation { get; set; } = null!;

        public IEnumerable<SelectListItem>? CategoryselectListItem { get; set; } 

    }
}
