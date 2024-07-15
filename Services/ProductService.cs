using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Data.Models;
using _2Good2EatBackendStore.Services;
using _2Good2EatStore.Data;
using _2Good2EatStore.Data.Interfaces;


namespace _2Good2EatStore.Services
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
            else if (!Object.ReferenceEquals(trackedReference, product))
            {
                _dbContext.Entry(trackedReference).CurrentValues.SetValues(product);
            }

            _dbContext.SaveChanges();
        }

        public IQueryable<Product> GetFilteredProducts(ProductSearchModel searchOptions)
        {
            var predicate = PredicateBuilderService.False<Product>();
            if (!searchOptions.showInvisible)
            {
                predicate = predicate.And(x => x.IsVisible);
            }

            if (!searchOptions.showDeleted)
            {
                predicate = predicate.And(x => !x.IsDeleted);
            }

            if(searchOptions.ProductTypes.Count > 0)
            {
                foreach(var type in searchOptions.ProductTypes)
                {
                    predicate = predicate.Or(x => x.ProductType == type);
                }
               
            }
            return GetAllProducts().Where(predicate);
        }
    }
}
