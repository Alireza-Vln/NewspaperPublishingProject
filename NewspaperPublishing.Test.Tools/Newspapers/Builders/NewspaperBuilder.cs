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
               
                Date = new DateTime(2020, 10, 10)

            };
            
        }
        public NewspaperBuilder WithNewsId(int newsId)
        {
            
            return this;
        }
        public Newspaper Build()
        {
            return _newspaper;
        } 
    }
}

