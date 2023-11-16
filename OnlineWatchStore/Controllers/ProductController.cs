using Microsoft.AspNetCore.Mvc;
using OnlineWatchStore.Models;
using OnlineWatchStore.Repositories;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Controllers
{
    public class ProductController : Controller
    {
        public WatchStoreDbContext context;
        private readonly ProductRepo productRepo;
        public ProductController(WatchStoreDbContext context)
        {
            this.context = context;
            productRepo = new ProductRepo(context);

        }
        public IActionResult Index()
        {
            return View();
        }
        #region Product
        public IActionResult AllProducts()
        {
            var vm = new ProductVM();
            ViewBag.Brands = context.Brands.ToList();
            ViewBag.Categories = context.Categories.ToList();
            productRepo.GetAllProducts(vm);
            return View(vm);
        }
        //public IActionResult AddNewProduct()
        //{
        //    var vm = new ProductVM();
        //    return PartialView(vm);
        //}
        [HttpPost]
        public IActionResult AddNewProduct(ProductVM vm)
        {
            productRepo.AddNewProduct(vm);

            return RedirectToAction("AllProducts");
        }
        public IActionResult EditProduct(int id)
        {
            return View();
        }
        #endregion Product
    }
}
