using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Services.Tags.Contracts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public interface TagRepository
    {
        void Add(Tag tag);
        void Delete(Tag tag);
        Tag? FindTagById(int id);
        Tag? FindTagTitle(string title);
        List<GetTagDto> GetAll();
    }
}
