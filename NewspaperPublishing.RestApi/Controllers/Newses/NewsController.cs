using Microsoft.AspNetCore.Mvc;
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
    }
}
