using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Entities.Newses
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int View { get; set; }
        public int Weight { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
   

    }
}
