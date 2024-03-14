namespace NewspaperPublishing.Spec.Tests.Newses
{
    public interface NewsService
    {
        Task Add(int categoryId, int authorId,AddNewsDto dto);
        Task Update(int id, UpdateNewsDto dto);
    }
}
