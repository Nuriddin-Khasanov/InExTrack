using InExTrack.DTOs;
using InExTrack.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        //private static readonly List<Category> _categories = new();

        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategories(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategoryById(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.CreateCategory(categoryDto, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryDto updatedCategory, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.UpdateCategory(id, updatedCategory, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.DeleteCategory(id, cancellationToken));
        }

    }
}
