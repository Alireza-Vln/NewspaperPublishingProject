using NewspaperPublishing.Services.Tags.Contracts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public interface TagService
    {
        Task Add(int categoryId,AddTagDto dto);
        Task Delete(int id);
        Task<List<GetTagDto>> Get();
        Task Update(int id, UpdateTagDto dto);
    }
}
