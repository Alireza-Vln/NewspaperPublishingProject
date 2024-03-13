using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Persistence.EF;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public class EFTagRepository:TagRepository
    {
        readonly DbSet<Tag> _tags;
        public EFTagRepository(EFDataContext context)
        {
            _tags = context.Tags;
        }

        public void Add(Tag tag)
        {
            _tags.Add(tag);
        }

        public void Delete(Tag tag)
        {
            _tags.Remove(tag);
        }

        public Tag? FindTagById(int id)
        {
           return _tags.FirstOrDefault(_ => _.Id == id);
        }

        public Tag? FindTagTitle(string title)
        {
            return _tags.FirstOrDefault(_=>_.Title == title);
        }
    }
}
