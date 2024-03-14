using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
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
        [HttpDelete]
        public async Task Delete([FromQuery]int id)
        {
            await _service.Delete(id);
        }
        [HttpPatch]
        public async Task Update([FromQuery]int id, [FromBody]UpdateAuthorDto dto)
        {
            await _service.Update(id, dto);
        }
        [HttpGet]
        public async Task<List<GetAuthorsDto>> GetAll()
        {
           return await _service.Get();
        }
    }
}
