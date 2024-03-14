using NewspaperPublishing.Entities.Newspapers;

namespace NewspaperPublishing.Persistence.EF.Newspapers
{
    public interface NewspaperRepository    
    {
        Newspaper? FindNewspaperByNews(int newsId);
    }
}
