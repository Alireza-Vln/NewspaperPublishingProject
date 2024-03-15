using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;

namespace NewspaperPublishing.Persistence.EF.Newspapers
{
    public interface NewspaperRepository    
    {
        void Add(Newspaper newspaper);
        bool FindNewspaperByNews(int newsId);
    }
}
