using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatStore.Interfaces;

namespace _2Good2EatStore.Services
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
