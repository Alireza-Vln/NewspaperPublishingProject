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
        public int AuthorId { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
