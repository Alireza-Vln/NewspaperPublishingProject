using NewspaperPublishing.Entities.Newses;

namespace NewspaperPublishing.Entities.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int View { get; set; }
        public HashSet<News> News { get; set; }
        public Author()
        {
            News = new ();
        }
    }
}
