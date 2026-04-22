using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;

namespace TeguhJaya.Api.Controllers
{
    /* Menunjukkan bahwa semua api untuk melayani HTTP API response */
    [ApiController] 
    [Route("[controller]")] /* Prefix route dengan nama controller */
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _repository;

        public ProductsController(ILogger <ProductsController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet("/Categories/{categoryId}/Products")]
        public IActionResult GetProductsByCategory([FromRoute] int categoryId)
        {
            _logger.LogInformation("GetProductsByCategoryId started");
            try
            {
                var products = _repository.GetProductsByCategory(categoryId);
                _logger.LogInformation("GetProductsByCategoryId finished successfully");
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while retrieving products");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            _logger.LogInformation("GetProduct started");
            try
            {
                var product = _repository.GetProduct(id);
                _logger.LogInformation("GetProduct finished successfully");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while retrieving product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _logger.LogInformation("CreateProduct started");
            try
            {
                _repository.CreateProduct(product);
                _logger.LogInformation("CreateProduct finished successfully");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while creating product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch]
        public IActionResult UpdateProduct([FromBody] int id)
        {
            _logger.LogInformation("UpdateProduct started");
            try
            {
                _repository.UpdateProduct(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while updating product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _logger.LogInformation("DeleteProduct started");
            try
            {
                _repository.DeleteProduct(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while deleting product");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}