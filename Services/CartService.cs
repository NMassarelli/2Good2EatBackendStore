using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatStore.Data.Interfaces;

namespace _2Good2EatStore.Data.Services
{
    public class CartService(IProductService productService) : ICartService
    {
        private readonly IProductService _productService = productService;

        public List<Product> selectedProducts { get; set; } = [];

        public void AddProductToCart(int productId)
        {
          selectedProducts.Add(_productService.GetProductById(productId));
        }

    }
}
