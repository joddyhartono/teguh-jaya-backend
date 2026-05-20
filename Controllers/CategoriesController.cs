using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeguhJaya.Api.Interfaces;
using TeguhJaya.Api.Models;

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
                _logger.LogError(ex, "Error occurred while retrieving categories");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            _logger.LogInformation("GetCategory started");
            try
            {
                var category = _repository.GetCategory(id);
                _logger.LogInformation("GetCategory finished successfully");
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving category");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _logger.LogInformation("CreateCategory started");
            try
            {
                var result = _repository.CreateCategory(category);
                _logger.LogInformation("CreateCategory finished successfully");
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating category");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            _logger.LogInformation("UpdateCategory started");
            try
            {
                category.Id = id;
                var result = _repository.UpdateCategory(category);
                if(result == 0)
                {
                    NotFound("Category not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating category");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPatch("{id}/delete")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            _logger.LogInformation("DeleteCategory started");
            try
            {
                var result = _repository.DeleteCategory(id);
                if(result == 0)
                {
                    NotFound("Category not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting category");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}