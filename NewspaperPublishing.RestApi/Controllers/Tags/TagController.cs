using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Spec.Tests.Tags;

namespace NewspaperPublishing.RestApi.Controllers.Tags
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : Controller
    {
        readonly TagService _service;
        public TagController(TagService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddTag([FromQuery] int categoryId, [FromBody] AddTagDto dto)
        {
            await _service.Add(categoryId, dto);
        }
    }
}
