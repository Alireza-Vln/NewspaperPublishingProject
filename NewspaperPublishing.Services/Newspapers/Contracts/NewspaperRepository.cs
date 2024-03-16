using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newspapers;

namespace NewspaperPublishing.Persistence.EF.Newspapers
{
    public interface NewspaperRepository    
    {
        void Add(Newspaper newspaper);
        List<GetNewspaperDto> Get(FilterNewspaperDto? dto);
    }
}
