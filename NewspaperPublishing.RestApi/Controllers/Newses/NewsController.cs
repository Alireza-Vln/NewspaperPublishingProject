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
    }
}
