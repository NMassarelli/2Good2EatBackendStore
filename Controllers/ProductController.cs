using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace _2Good2EatBackendStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        // GET: api/<ProductController>
        [HttpPost("GetFilteredProducts")]
        public IEnumerable<ProductModel> GetFilteredProducts([FromBody] ProductSearchModel? searchTerms)
        {
            searchTerms ??= new ProductSearchModel();
            return _productService.GetFilteredProducts(searchTerms).ToList().MapToModelList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _productService.GetProductById(id).MapToModel();
        }

        // POST api/<ProductController>
        [HttpPost("Save")]
        public void Post([FromBody] ProductModel value)
        {
            _productService.SaveProduct(value.MapToEntity());
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
