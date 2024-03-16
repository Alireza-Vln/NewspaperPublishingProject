using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public interface NewspaperService
    {
        Task Add(AddNewspaperDto dto);
        Task <List<GetNewspaperDto>> Get();
    }
}
