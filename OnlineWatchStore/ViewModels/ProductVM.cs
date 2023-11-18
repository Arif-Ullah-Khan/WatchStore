using OnlineWatchStore.Models;

namespace OnlineWatchStore.ViewModels
{
    public class ProductVM
    {
        public Product ProductItem { get; set; }
        public Stock StockItem { get; set; }
        public List<Product> ProductList { get; set; }

        public IFormFile ImagePath { get; set; }
    }
}
