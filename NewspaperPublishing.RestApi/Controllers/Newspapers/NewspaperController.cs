using Microsoft.AspNetCore.Mvc;
using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
using NewspaperPublishing.Services.Tags.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using NewspaperPublishing.Services.Unit.Tests.Newspapers;
using NewspaperPublishing.Spec.Tests.Newspapers;

namespace NewspaperPublishing.RestApi.Controllers.Newspapers
{
    [ApiController]
    [Route("api/newspapers")]
    public class NewspaperController : Controller
    {
        readonly NewspaperService _service;
        public NewspaperController(NewspaperService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add(AddNewspaperDto dto)
        {
            await _service.Add(dto);
        }
        [HttpGet]
        public async Task<List<GetNewspaperDto>> Get([FromQuery]FilterNewspaperDto? filterDto)
        {
            return await _service.Get(filterDto);
        } 
    }
}
