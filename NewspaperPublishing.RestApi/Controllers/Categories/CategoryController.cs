using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Spec.Tests.Categories;

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
    }
}
