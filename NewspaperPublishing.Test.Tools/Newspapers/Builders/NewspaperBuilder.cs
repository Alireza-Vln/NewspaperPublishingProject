using NewspaperPublishing.Entities.Newspapers;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public class NewspaperBuilder 
    {
        readonly Newspaper _newspaper;
        public NewspaperBuilder()
        {
            _newspaper = new Newspaper()
            {
                Title = "dummy-title",
                NewsId = 1,
                Date = new DateTime(2020, 10, 10)

            };
            
        }
        public NewspaperBuilder WithNewsId(int newsId)
        {
            _newspaper.NewsId =newsId;
            return this;
        }
        public Newspaper Build()
        {
            return _newspaper;
        } 
    }
}

