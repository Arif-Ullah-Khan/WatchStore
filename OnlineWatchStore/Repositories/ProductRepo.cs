using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineWatchStore.Models;
using OnlineWatchStore.ViewModels;

namespace OnlineWatchStore.Repositories
{
    public class ProductRepo
    {
        public WatchStoreDbContext context;
        public ProductRepo(WatchStoreDbContext context)
        {
            this.context = context;
        }

        public void GetAllProducts(ProductVM vm)
        {
            vm.ProductList = context.Products.ToList();
        }
        public void GetSpecficProduct(int id, ProductVM vm)
        {
            vm.ProductItem = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            vm.StockItem = context.Stocks.Where(x => x.ProductId == id).FirstOrDefault();

        }
        public int AddNewProduct(ProductVM vm)
        {
            try
            {
                //string uniqueFileName = null;
                //if (vm.ImagePath != null)
                //{
                //    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.ImagePath.FileName;
                //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        vm.ImagePath.CopyTo(fileStream);
                //    }
                //}
                var entity = new Product
                {
                    Name = vm.ProductItem.Name,
                    BrandName = vm.ProductItem.BrandName,
                    CategoryName = vm.ProductItem.CategoryName,
                    Price = vm.ProductItem.Price,
                    Description = vm.ProductItem.Description,
                };

                context.Products.Add(entity);
                var a = context.SaveChanges();
                if (a > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public void UpdateProduct(ProductVM vm)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var findentity = context.Products.Where(x => x.ProductId == vm.ProductItem.ProductId).FirstOrDefault();
                    if (findentity != null)
                    {

                        if (vm.ImagePath != null && vm.ImagePath.Length > 0)
                        {
                            var path = "";
                            // Get the file name and path
                            var fileName = Path.GetFileName(vm.ImagePath.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                            // Save the file to the server
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                vm.ImagePath.CopyTo(stream);
                            }

                            // Update the ProductVM with the file path
                            path = fileName;
                            findentity.Image = path;
                        }

                        findentity.Name = vm.ProductItem.Name;
                        findentity.CategoryName = vm.ProductItem.CategoryName;
                        findentity.BrandName = vm.ProductItem.BrandName;
                        findentity.Price = vm.ProductItem.Price;
                        findentity.Description = vm.ProductItem.Description;
                        context.Products.Update(findentity);
                        var a = context.SaveChanges();
                        if (a > 0)
                        {
                            var stockitem = context.Stocks.Where(x => x.ProductId == vm.ProductItem.ProductId).FirstOrDefault();
                            if (stockitem != null)
                            {
                                stockitem.QuantityAvailable = vm.StockItem.QuantityAvailable;
                                context.Stocks.Update(stockitem);
                            }
                            else
                            {
                                var item = new Stock
                                {
                                    ProductId = vm.ProductItem.ProductId,
                                    QuantityAvailable = vm.StockItem.QuantityAvailable
                                };
                                context.Stocks.Add(item);
                            }
                            context.SaveChanges();
                            transaction.Commit();
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
    }
}
