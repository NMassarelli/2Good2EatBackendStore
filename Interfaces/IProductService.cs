using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Data.Models;

namespace _2Good2EatStore.Interfaces
{
    public interface IProductService 
    {
        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetFilteredProducts(ProductSearchModel searchOptions);
        Product GetProductById(int id);
        void SaveProduct(Product product);
        void DeleteProduct(int id);
    }
}
