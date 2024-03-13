using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Services.Tags.Contracts.Dtos;
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
        [HttpDelete]
        public async Task DeleteTag([FromQuery]int tagId)
        {
            await _service.Delete(tagId);
        }
        [HttpPatch]
        public async Task UpdateTag([FromQuery] int id, [FromBody] UpdateTagDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpGet]
        public async Task<List<GetTagDto>> GetAll()
        {
             return await _service.Get();
        }
    }
}
