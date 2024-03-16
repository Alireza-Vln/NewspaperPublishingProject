using NewspaperPublishing.Services.Authors.Contarcts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public interface AuthorService
    {
        Task Add(AddAuthorDto dto);
        Task Delete(int id);
        Task<List<GetAuthorsDto>> Get();
        Task<List<GetAuthorsDto>> GetAuthorMostNews();
        Task Update(int id, UpdateAuthorDto dto);
    }
}
