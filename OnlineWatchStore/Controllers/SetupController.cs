using Microsoft.AspNetCore.Mvc;
using OnlineWatchStore.Models;
using OnlineWatchStore.Repositories;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Controllers
{
    public class SetupController : Controller
    {
        public WatchStoreDbContext context { get; set; }
        private SetupRepo setupRepo { get; set; }

        public SetupController(WatchStoreDbContext context)
        {
            this.context = context;
            setupRepo = new SetupRepo(context);
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Brand
        public IActionResult AllBrands()
        {
            var vm = new SetupVM();
            setupRepo.GetAllBrands(vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddNewBrand(SetupVM setupVM)
        {
            setupRepo.AddNewBrand(setupVM);

            return RedirectToAction("AllBrands");
        }
        public IActionResult EditBrand(int id)
        {
            return View();
        }
        #endregion Brand

        #region Categories
        public IActionResult AllCategories()
        {
            var vm = new SetupVM();
            setupRepo.GetAllCategories(vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddNewCategory(SetupVM setupVM)
        {
            setupRepo.AddNewCategory(setupVM);

            return RedirectToAction("AllCategories");
        }
        public IActionResult EditCategory(int id)
        {
            return View();
        }
        #endregion Categories
    }
}
