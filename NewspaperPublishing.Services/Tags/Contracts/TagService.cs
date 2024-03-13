namespace NewspaperPublishing.Spec.Tests.Tags
{
    public interface TagService
    {
        Task Add(int id,AddTagDto dto);
        Task Delete(int id);
    }
}
