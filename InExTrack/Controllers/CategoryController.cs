using InExTrack.Common;
using InExTrack.DataContext;
using InExTrack.DTOs;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InExTrack.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDBContext _context;

        public CategoryController(ICategoryService categoryService, AppDBContext context)
        {
            _categoryService = categoryService;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategories(getUserId(), cancellationToken);
            return Ok(categories);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategoryById(getUserId(), id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.CreateCategory(getUserId(), categoryDto, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryDto updatedCategory, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.UpdateCategory(getUserId(), id, updatedCategory, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.DeleteCategory(getUserId(), id, cancellationToken));
        }

    }
}
