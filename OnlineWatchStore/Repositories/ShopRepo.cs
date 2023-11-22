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
            vm.GetProductList = query.ToList();
        }
        public void ViewProductDetail(int id, ShopVM vm)
        {
            vm.Product = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            vm.Stock = context.Stocks.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public int AddToCart(ShopVM vm)
        {
            var checkuser = context.Carts.Where(x => x.UserId == 1).FirstOrDefault();
            if (checkuser == null)
            {
                var cart = new Cart
                {
                    UserId = 1,
                    TotalPrice = 0
                };
                context.Carts.Add(cart);
                context.SaveChanges();
            }
            int cartid = context.Carts.Where(x => x.UserId == 1).Select(s => s.CartId).FirstOrDefault();
            return cartid;
        }
        public void AddProductToCartItem(ShopVM vm, int CartId)
        {
            try
            {
                var totalprice = vm.Product.Price * vm.Quantity;
                var cartitem = new CartItem
                {
                    CartId = CartId,
                    ProductId = vm.Product.ProductId,
                    Quantity = vm.Quantity,
                    Price = vm.Product.Price,
                    TotalPrice = totalprice
                };
                context.CartItems.Add(cartitem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void GetCartList(ShopVM vm,int cartid)
        {
            try
            {
                vm.CartItemList = context.CartItems.Where(x => x.CartId == cartid).Include(x=>x.Product).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
