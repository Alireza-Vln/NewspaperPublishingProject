using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Persistence.EF;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class EFAuthorRepository :AuthorRepository
    {
        readonly DbSet<Author> _authors;
        public EFAuthorRepository(EFDataContext context)
        {
            _authors = context.Authors;
        }

        public void Add(Author author)
        {
           _authors.Add(author);
        }
    }
}
