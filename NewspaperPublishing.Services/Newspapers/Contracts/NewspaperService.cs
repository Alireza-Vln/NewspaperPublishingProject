using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newspapers;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public interface NewspaperService
    {
        Task Add(AddNewspaperDto dto);
        Task <List<GetNewspaperDto>> Get(FilterNewspaperDto? dto);
    }
}
