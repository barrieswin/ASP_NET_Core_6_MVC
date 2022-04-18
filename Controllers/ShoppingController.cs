using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Web;
using WebAppOceanShop.Models;
using WebAppOceanShop.ViewModel;
using WebAppOceanShop.Helpers;



namespace WebAppOceanShop.Controllers
{
    public class ShoppingController : Controller
    {
        //Define DbContext _context
        private readonly OceanCartDbContext _context;


        public ShoppingController(OceanCartDbContext context)
        {
            _context = context;
        }

        //GET : Index
        public IActionResult Index()
        {
            //Map the data from EntityFrameworkCore.DbContext into ShoppingViewModel
            IEnumerable<ShoppingViewModel> listOfShoppingViewModel = (from objItem in _context.TProducts
                                                                      select new ShoppingViewModel
                                                                      {
                                                                          FId = objItem.FId,
                                                                          FCategory = objItem.FCategory,
                                                                          FPid = objItem.FPid,
                                                                          FName = objItem.FName,
                                                                          FDescription = objItem.FDescription,
                                                                          FPrice = objItem.FPrice,
                                                                          FImagePath = objItem.FImagePath,
                                                                          FIsActiveFlag = objItem.FIsActiveFlag
                                                                      }
                                                                       ).ToList();

            return View(listOfShoppingViewModel);
        }








//        public IActionResult AddtoCart(int id)
//        {
//            //取得商品資料
//            CartItem item = new CartItem
//            {
//                Product = _context.TProducts.Single(x => x.FId == id).FName,
//                Amount = 1,
//                SubTotal = _context.TProducts.Single(m => m.FId == id).FPrice
//            };

//            //判斷 Session 內有無購物車
//            if (SessionHelper.
//                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
//            {
//                //如果沒有已存在購物車: 建立新的購物車
//                List<CartItem> cart = new List<CartItem>();
//                cart.Add(item);
//                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            }
//            else
//            {
//                //如果已存在購物車: 檢查有無相同的商品，有的話只調整數量
//                List<CartItem> cart = SessionHelper.
//                    GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

//                int index = cart.FindIndex(m => m.Id.Equals(id));
//                if (index != -1)
//                {
//                    cart[index].Amount += item.Amount;
//                    cart[index].SubTotal += item.SubTotal;
//                }
//                else
//                {
//                    cart.Add(item);
//                }
//                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            }

//            return NoContent(); // HttpStatus 204: 請求成功但不更新畫面
//        }


//        public IActionResult RemoveItem(int id)
//        {
//            //向 Session 取得商品列表
//            List<CartItem> cart = SessionHelper.
//                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

//            //用FindIndex查詢目標在List裡的位置
//            int index = cart.FindIndex(m => m.Id.Equals(id));
//            cart.RemoveAt(index);

//            if (cart.Count < 1)
//            {
//                SessionHelper.Remove(HttpContext.Session, "cart");
//            }
//            else
//            {
//                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//            }

//            return RedirectToAction("Index");
//        }

//        public IActionResult ShoppingCart()
//        {
//            //向 Session 取得商品列表
//            List<CartItem> CartItems = SessionHelper.
//                GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

//            //計算商品總額
//            if (CartItems != null)
//            {
//                ViewBag.Total = CartItems.Sum(m => m.SubTotal);
//            }
//            else
//            {
//                ViewBag.Total = 0;
//            }

//            return View(CartItems);
//        }






    }
}
