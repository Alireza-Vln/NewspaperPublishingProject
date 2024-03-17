using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Services.Categories.Contracts.Dtos;
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
        [HttpGet]
        public async Task<List<GetCategoryDto>> GetAllCategory()
        {
           return await _service.GetAll();
        }
        [HttpGet("WithMostNews")]
        public async Task<List<GetCategoryDto>> GetCategoriesWithMostNews()
        {
            return await _service.GetCategoryMostNews();
        }
        [HttpGet("WithMostView")]
        public async Task <List<GetCategoryDto>> GetCategoriesWithMostView()
        {
            return await _service.GetCategoryMostView();
        }
    }
}
