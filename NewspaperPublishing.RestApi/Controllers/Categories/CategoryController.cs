using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Factories;

namespace NewspaperPublishing.RestApi.Controllers.Categories
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : Controller
    {
        readonly CategoryService _service;
        public CategoryController(CategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddCategory(AddCategoryDto dto)
        {
            await _service.Add(dto);
        }
        [HttpPatch]
        public async Task UpdateCategory([FromQuery] int Id, [FromBody] UpdateCategoryDto dto)
        {
            await _service.Update(Id, dto);
        }
        [HttpDelete]
        public async Task DeleteCategory([FromQuery] int categoryId)
        {
            await _service.Delete(categoryId);
        }
    }
}
