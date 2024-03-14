using NewspaperPublishing.Entities.Newses;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class NewsBuilder 
    {
        readonly News _news;
        public NewsBuilder()
        {
            _news = new News()
            {
                Title = "dummy-title",
                Weight = 5,
                AuthorId = 1,
                CategoryId = 1,
                

            };
        }
        public NewsBuilder WithCategoryId(int categoryId)
        {
            _news.CategoryId = categoryId;
            return this;
        }
        public NewsBuilder WithAuthorId(int AuthorId)
        {
            _news.AuthorId= AuthorId;
            return this;
        }
        public News Build()
        {
            return _news;
        }

        public NewsBuilder WithWeight(int weight)
        {
            _news.Weight = weight;
            return this;
        }
    }
}
