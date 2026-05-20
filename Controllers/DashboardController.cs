using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeguhJaya.Api.Interfaces;

namespace TeguhJaya.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public DashboardController(ILogger<DashboardController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        
        [Authorize]
        [HttpGet]
        [Route("stats")]
        public IActionResult GetStats()
        {
            var totalCategories = _categoryRepository.GetTotal();
            var totalProducts = _productRepository.GetTotal();
            return Ok(new
            {
                TotalCategories = totalCategories,
                TotalProducts = totalProducts
            });
        }
    }
}