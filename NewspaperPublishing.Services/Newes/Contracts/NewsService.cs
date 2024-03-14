using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newses;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public interface NewsService
    {
        Task Add(int categoryId, int authorId,AddNewsDto dto);
        Task Delete(int id);
        Task<List<GetNewsDto>> Get(FiltersNewsDto filter);
        Task Update(int id, UpdateNewsDto dto);
    }
}
