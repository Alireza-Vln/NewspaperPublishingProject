using Microsoft.AspNetCore.Mvc;
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
    }
}
