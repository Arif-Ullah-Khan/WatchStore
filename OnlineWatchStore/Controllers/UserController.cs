using Microsoft.AspNetCore.Mvc;
using OnlineWatchStore.Models;
using OnlineWatchStore.Repositories;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Controllers
{
    public class UserController : Controller
    {
        private readonly WatchStoreDbContext context;
        private readonly UserRepo userRepo;

        public UserController(WatchStoreDbContext context)
        {
            this.context = context;
            userRepo = new UserRepo(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        #region User
        public IActionResult AllUsers()
        {
            var vm = new UserVM();
            userRepo.GetAllUsers(vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddNewUser(UserVM vm)
        {
            userRepo.AddNewUser(vm);
            return RedirectToAction("AllUsers");

        }
        public IActionResult Edit(int id)
        {
            var vm = new UserVM();
            userRepo.GetSpecficUser(id, vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(UserVM vm)
        {
            int a = userRepo.UpdateUser(vm);
            if (a == 1)
            {
                TempData["Success"] = "<script>alert('User Updated Successfully..!')</script>";
                return RedirectToAction("AllUsers");
            }
            else
            {
                ViewBag.Message = "Updating Failed..Phone or Username either are same";
                return View(vm);
            }
            
        }
        #endregion User
    }
}
