using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Web;
using WebAppOceanShop.Models;
using WebAppOceanShop.ViewModel;


namespace WebAppOceanShop.Controllers
{
    public class AdminController : Controller
    {
        //Define DbContext _context
        private readonly OceanCartDbContext _context;
        public AdminController(OceanCartDbContext context)
        {
            _context = context;
        }

        //GET: Index Page
        public IActionResult Index()
        {
            //Original code
            //Set DbContext
            // var viewModel = _context.TProducts.ToList();

            //Map the data from EntityFrameworkCore.DbContext into TProductViewModel
            IEnumerable<TProductViewModel> listOfTProductViewModel = (from objItem in _context.TProducts
                                                                    select new TProductViewModel
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

            return View(listOfTProductViewModel);
        }


        //GET : Add product into Database
        public IActionResult Create()
        {
            //LINQ to get the data from Table of TCategories
            //Sets the CategoryselectListItem
            TProductViewModel objTProductViewModel = new TProductViewModel();
            objTProductViewModel.CategoryselectListItem = (from objCat in _context.TCategories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.FCategoryName,
                                                           Value = objCat.FCategory.ToString(),
                                                           Selected = true
                                                       });
            return View(objTProductViewModel);
        }

        //POST : Create Product
        [HttpPost]
        public IActionResult Create(TProductViewModel objTProductViewModel)
        {
            //Upload Image to server:  wwwroot\Images
            //This is to upload Image, not ImagePath
            string fileName = "";
            try
            {
                fileName = Guid.NewGuid() + objTProductViewModel.FImage.FileName ;
                fileName = Path.GetFileName(fileName);
                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                var stream = new FileStream(uploadpath, FileMode.Create);
                objTProductViewModel.FImage.CopyToAsync(stream);
                //ViewBag.Message = "File uploaded successfully.";
            }
            catch
            {
                //ViewBag.Message = "Error while uploading the files.";
            }

            //Map Data from ViewModel into Models
            TProduct objItem = new TProduct();
            objItem.FCategory = objTProductViewModel.FCategory;
            objItem.FPid = objTProductViewModel.FPid;
            //objItem.FPid = Guid.NewGuid().ToString();  //this is to produce Guid for FPid
            objItem.FName = objTProductViewModel.FName;
            objItem.FDescription = objTProductViewModel.FDescription;
            objItem.FPrice = objTProductViewModel.FPrice;
            objItem.FImagePath = "~/images/" + fileName;
            objItem.FIsActiveFlag = true;

            //Add data to Database & save
            _context.TProducts.Add(objItem);
            _context.SaveChanges();

            //ADD ShowToast javaScript function here
            //TempData["message"]= "商品新增成功。";

            return Redirect("/Admin/Index");
        }


        //GET : Edit
        //This method uses EntityFrameworkCore.DbSet<TEntity>.Find(Object[]) 方法
        public IActionResult Edit(int? id)
        {
            //Get the data on the FId of TProducts
            var objItem = _context.TProducts.Find(id);
            return View(objItem);
        }


        //POST : Edit
        ///This method uses EntityFrameworkCore.DbSet<TEntity>.Find(Object[]) 方法
        [HttpPost]
        public IActionResult Edit(TProduct TProductModel)
        {
            //Bug: need to check if the input FId is valid

            //Map data of Edited items
            var objItem = _context.TProducts.Find(TProductModel.FId);
            objItem.FPid = TProductModel.FPid;
            objItem.FName = TProductModel.FName;
            objItem.FDescription = TProductModel.FDescription;
            objItem.FPrice = TProductModel.FPrice;

            _context.SaveChanges();
            return Redirect("/Admin/Index");
        }


        //GET : Delete
        //This method uses DbContext
        public IActionResult Delete(int? id)
        {
            //Get the data on the FId of TProducts
            var objItem = _context.TProducts.Find(id);
            return View(objItem);
        }

        //POST : Delete
        //Show the selected product, confirm on changing status
        //This method uses DbContext
        [HttpPost]
        public IActionResult Delete(TProduct TProductModel)
        {
            //map data
            var objItem = _context.TProducts.Find(TProductModel.FId);
            objItem.FIsActiveFlag = TProductModel.FIsActiveFlag;

            _context.SaveChanges();
            return Redirect("/Admin/Index");
        }
    }
}
