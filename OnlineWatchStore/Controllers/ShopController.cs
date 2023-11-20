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

        public ShopController(WatchStoreDbContext context)
        {
            this.context = context;
            shopRepo = new ShopRepo(context);
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
    }
}
