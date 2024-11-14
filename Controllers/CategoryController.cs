using Microsoft.AspNetCore.Mvc;
using CNLTHD.DTO;
using CNLTHD.Service.IService;
using Microsoft.AspNetCore.Authorization;

namespace CNLTHD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }

            return Ok(categories); 
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found.");
            }

            return Ok(category);
        }

        [HttpPost("createCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
            if (updatedCategory == null)
            {
                return NotFound($"Category with id {id} not found.");
            }

            return NoContent(); 
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound("Not Found or being referenced");
            }

            return NoContent();
        }
    }
}
