using OnlineWatchStore.Models;

namespace OnlineWatchStore.ViewModels
{
    public class ShopVM
    {
        public int Quantity { get; set; }
        public Product Product{ get; set; }
		public Stock Stock { get; set; }
		public List<getProducts> GetProductList { get; set; }
		public List<CartItem> CartItemList { get; set; }
    }
    public class getProducts
    {
        public Product Product { get; set; }
        public int? QuantityAvailable { get; set; }
    }
}
