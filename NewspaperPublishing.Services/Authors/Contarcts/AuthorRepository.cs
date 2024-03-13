using NewspaperPublishing.Entities.Authors;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public interface AuthorRepository
    {
        void Add(Author author);
    }
}
