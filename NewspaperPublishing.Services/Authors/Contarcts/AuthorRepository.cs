using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public interface AuthorRepository
    {
        void Add(Author author);
        void Delete(Author author);
        Author? FindAuthorById(int id);
        Author? FindAuthorByName(string author);
        List<GetAuthorsDto> GetAll();
        List<GetAuthorsDto> GetAuthorMostNews();
        List<GetAuthorsDto> GetAuthorMostViews();
    }
}
