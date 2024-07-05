using _2Good2EatBackendStore.Data.Entities;

namespace _2Good2EatStore.Data.Interfaces
{
    public interface IProductService 
    {
        IQueryable<Product> GetProducts();
        Product GetProductById(int id);
        void SaveProduct(Product product);
        void DeleteProduct(int id);
    }
}
