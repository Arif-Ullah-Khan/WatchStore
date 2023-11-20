using Microsoft.EntityFrameworkCore;
using OnlineWatchStore.Models;
using OnlineWatchStore.ViewModels;
using Dapper;


namespace OnlineWatchStore.Repositories
{
    public class ShopRepo
    {
        private readonly WatchStoreDbContext context;
        public ShopRepo(WatchStoreDbContext context)
        {
            this.context = context;
        }

        public void getProjectsForShop(ShopVM vm)
        {
            var query = from p in context.Products
                        join s in context.Stocks on p.ProductId equals s.ProductId
                        select new getProducts { Product = p, QuantityAvailable = s.QuantityAvailable };

            // Assuming GetProductList is a List<getProducts> property
            vm.GetProductList = query.ToList();
            //foreach (var result in query)
            //{
            //    vm.GetProductList = result
            //}
        }
    }
}
