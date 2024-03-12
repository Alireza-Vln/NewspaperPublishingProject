using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;

namespace NewspaperPublishing.Entities.Newspapers
{
    public class Newspaper
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public List<Category> Categories { get; set; }
        public List<News> News { get; set; }
        public Newspaper()
        {
            Categories = new List<Category>();
            News = new List<News>();
        }
    }
}
