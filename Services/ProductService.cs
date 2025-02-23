﻿using _2Good2EatBackendStore.Data;
using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Enums;
using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;

namespace _2Good2EatBackendStore.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        private readonly ApplicationDbContext _dbContext = context;

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _dbContext.Products.AsQueryable();
        }

        public void SaveProduct(Product product)
        {
            var trackedReference = _dbContext.Products.Local.SingleOrDefault(p => p.Id == product.Id);

            if (trackedReference == null)
            {
                _dbContext.Products.Update(product);
            }
            else if (!ReferenceEquals(trackedReference, product))
            {
                _dbContext.Entry(trackedReference).CurrentValues.SetValues(product);
            }

            _dbContext.SaveChanges();
        }

        public IQueryable<Product> GetFilteredProducts(ProductSearchModel searchOptions)
        {

            var finalList = GetAllProducts();

            if (!searchOptions.ShowInvisible)
            {
                finalList = finalList.Where(x => x.IsVisible);
            }

            if (!searchOptions.ShowDeleted)
            {
                finalList = finalList.Where(x => !x.IsDeleted);
            }

            if (!searchOptions.ShowOutOfStock)
            {
                finalList = finalList.Where(x => x.Inventory > 0);
            }

            if (searchOptions.ProductTypes.Count > 0)
            {
                foreach (var type in searchOptions.ProductTypes)
                {
                    finalList = finalList.Where(x => searchOptions.ProductTypes.Contains(x.ProductType));
                }

            }
            else
            {
                finalList = finalList.Where(x => x.ProductType == ProductTypeEnum.None);
            }

            return finalList;
        }
    }
}
