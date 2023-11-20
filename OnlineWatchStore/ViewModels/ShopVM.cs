using OnlineWatchStore.Models;

namespace OnlineWatchStore.ViewModels
{
    public class ShopVM
    {
        public List<getProducts> GetProductList { get; set; }
    }
    public class getProducts
    {
        public Product Product { get; set; }
        public int? QuantityAvailable { get; set; }
    }
}
