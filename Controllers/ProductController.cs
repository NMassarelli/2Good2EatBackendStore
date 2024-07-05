using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Data.Models;
using _2Good2EatStore.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2Good2EatBackendStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productService.GetProducts().ToList().MapToModelList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _productService.GetProductById(id).MapToModel();
        }

        // POST api/<ProductController>
        [HttpPost]
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
