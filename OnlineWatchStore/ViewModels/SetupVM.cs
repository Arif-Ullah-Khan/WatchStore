using OnlineWatchStore.Models;

namespace OnlineWatchStore.ViewModels
{
    public class SetupVM
    {
        public Brand BrandItem { get; set; }
        public List<Brand> BrandList { get; set; }
        public Category CategoryItem { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
