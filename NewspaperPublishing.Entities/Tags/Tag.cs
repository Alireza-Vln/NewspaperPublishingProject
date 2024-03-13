using NewspaperPublishing.Entities.Categories;

namespace NewspaperPublishing.Entities.Tags
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int NewsId { get; set; }

    }
}
