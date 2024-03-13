using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public interface TagRepository
    {
        void Add(Tag tag);
        void Delete(Tag tag);
        Tag? FindTagById(int id);
        Tag? FindTagTitle(string title);
    }
}
