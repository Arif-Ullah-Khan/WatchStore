﻿using Microsoft.EntityFrameworkCore;
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
        public void GetSpecficProduct()
        {

        }
        public int AddNewProduct(ProductVM vm)
        {
            try
            {
                var productid = context.Products.Max(m => m.ProductId) + 1;
                var entity = new Product
                {
                    ProductId = productid,
                    Name = vm.ProductItem.Name,
                    BrandName = vm.ProductItem.BrandName,
                    CategoryName = vm.ProductItem.CategoryName,
                    Price = vm.ProductItem.Price,
                    Description = vm.ProductItem.Description

                };
                context.Products.Add(entity);
                var a = context.SaveChanges();
                if (a>0)
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
        public void UpdateProduct()
        {

        }
    }
}
