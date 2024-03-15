using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperCategories;
using NewspaperPublishing.Entities.NewspaperNewses;

namespace NewspaperPublishing.Entities.Newspapers
{
    public class Newspaper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public HashSet<NewspaperCategory> NewspaperCategories { get; set; }
        public HashSet<NewspaperNews> NewspaperNews { get; set; }
        public Newspaper()
        {
            NewspaperCategories = new();
            NewspaperNews = new();
        }


    }
}
