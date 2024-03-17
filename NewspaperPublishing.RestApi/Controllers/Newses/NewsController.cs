using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Services.Newes.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using NewspaperPublishing.Spec.Tests.Newses;

namespace NewspaperPublishing.RestApi.Controllers.Newses
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : Controller
    {
      readonly NewsService _service;
        public NewsController(NewsService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddNews([FromQuery] int categoryId,
                                   [FromQuery] int authorId,
                                   [FromBody] AddNewsDto dto)
        {
            await _service.Add(categoryId,authorId, dto);
        }
        [HttpPatch]
        public async Task UpdateNews([FromQuery] int newsId,
                                   [FromBody] UpdateNewsDto newsDto)
        {
            await _service.Update(newsId, newsDto);
        }
        [HttpDelete]
        public async Task DeleteNews([FromQuery] int newsId)
        {
            await _service.Delete(newsId);
        }
        [HttpGet]
        public async Task<List<GetNewsDto>> Get([FromQuery] FiltersNewsDto dto)
        {
            return await _service.Get(dto);
        }
        [HttpGet("WithMostView")]
        public async Task<List<GetNewsDto>> GetNewsWithMostView()
        {
            return await _service.GetNewsMostView();
        }
                                                    
    }
}
