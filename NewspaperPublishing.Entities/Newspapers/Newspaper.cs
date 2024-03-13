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
        public News News { get; set; }
        public int NewsId { get; set; }
       // public List<int> NewsesId { get; set; }
        public Newspaper()
        { 
           // NewsesId = new List<int>();
        }
    }
}
