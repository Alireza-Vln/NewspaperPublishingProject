using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Entities.Newses
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NewspaperId { get; set; }
        public int View { get; set; }
        public int Weight { get; set; }
        public Author Author { get; set; }
        public Newspaper Newspaper { get; set; }
        public int AuthorId { get; set; }
        public List<Tag> Tags { get; set; }
        public News()
        {
            Tags = new List<Tag>();
        }

    }
}
