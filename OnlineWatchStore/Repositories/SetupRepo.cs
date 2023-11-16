using OnlineWatchStore.Models;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Repositories
{
    public class SetupRepo
    {
        public WatchStoreDbContext context { get; set; }
        public SetupRepo(WatchStoreDbContext context)
        {
            this.context = context;
        }
        #region Brand
        public void GetAllBrands(SetupVM setupVM)
        {
            setupVM.BrandList = context.Brands.ToList();
        }
        public void GetSpecficBrand()
        {

        }
        public void AddNewBrand(SetupVM setupVM)
        {
            var entity = new Brand
            {
                BrandName = setupVM.BrandItem.BrandName
            };
            context.Brands.Add(entity);
            context.SaveChanges();
        }
        public void UpdateBrand()
        {

        }
        #endregion Brand

        #region Categories
        public void GetAllCategories(SetupVM setupVM)
        {
            setupVM.CategoryList = context.Categories.ToList();
        }
        public void GetSpecficCategory()
        {

        }
        public void AddNewCategory(SetupVM setupVM)
        {
            var entity = new Category
            {
                CategoryName = setupVM.CategoryItem.CategoryName
            };
            context.Categories.Add(entity);
            context.SaveChanges();
        }
        public void UpdateCategory()
        {

        }
        #endregion Categories
    }
}
