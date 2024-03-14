namespace NewspaperPublishing.Spec.Tests.Authors
{
    public interface AuthorService
    {
        Task Add(AddAuthorDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateAuthorDto dto);
    }
}
