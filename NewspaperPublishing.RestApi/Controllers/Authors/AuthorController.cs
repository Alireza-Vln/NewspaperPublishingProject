using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Spec.Tests.Authors;

namespace NewspaperPublishing.RestApi.Controllers.Authors
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        readonly AuthorService _service;
        public AuthorController(AuthorService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddAuthorDto dto)
        {
            await _service.Add(dto);    
        }
    }
}
