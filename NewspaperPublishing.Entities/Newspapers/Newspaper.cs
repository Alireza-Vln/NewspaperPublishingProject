using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;

namespace NewspaperPublishing.Entities.Newspapers
{
    public class Newspaper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
     
    }
}
