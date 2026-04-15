using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeguhJaya.Api.Interfaces;

namespace TeguhJaya.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _repository;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetCategories()
        {
            _logger.LogInformation("GetCategories started");
            try
            {
                var categories = _repository.GetCategories();
                _logger.LogInformation("GetCategories finished successfully");
                return Ok(categories);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occured while retrieving categories");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}