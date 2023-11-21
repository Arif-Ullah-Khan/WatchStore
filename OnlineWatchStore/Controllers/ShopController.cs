using Microsoft.AspNetCore.Mvc;
using OnlineWatchStore.Models;
using OnlineWatchStore.Repositories;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly WatchStoreDbContext context;
        private readonly ShopRepo shopRepo;
        private readonly ProductRepo productRepo;

        public ShopController(WatchStoreDbContext context)
        {
            this.context = context;
            shopRepo = new ShopRepo(context);
            productRepo = new ProductRepo(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewProducts(ShopVM vm)
        {
            shopRepo.getProjectsForShop(vm);
            return View(vm);
        }
        public IActionResult View(int id)
        {
            var vm = new ShopVM();
            shopRepo.ViewProductDetail(id, vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddToCart(ShopVM vm)
        {

            int cartid = shopRepo.AddToCart(vm);
            shopRepo.AddProductToCartItem(vm, cartid);
            return View();
        }
    }
}
