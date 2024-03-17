using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewsTags;
using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class NewsBuilder
    {
        readonly News _news;
        readonly NewsTag _newsTag;
        public NewsBuilder()
        {
            _news = new News()
            {
                Title = "dummy-title",
                Weight = 5,
                AuthorId = 1,
                CategoryId = 1,
                NewsTags = new HashSet<NewsTag>
                {
                    new NewsTag()
                    {
                        TagId = 1,
                    }
                },
                View = 0,

            };
        }
        public NewsBuilder WithCategoryId(int categoryId)
        {
            _news.CategoryId = categoryId;
            return this;
        }
        public NewsBuilder WithTags(int Tag)
        {
            _news.NewsTags.Select(_ => _.TagId == Tag);
            return this;
        }
        public NewsBuilder WithAuthorId(int AuthorId)
        {
            _news.AuthorId = AuthorId;
            return this;
        }
        public NewsBuilder WithTitle(string Title)
        {
            _news.Title = Title;
            return this;
        }
        public NewsBuilder WithView(int View)
        {
            _news.View = View;
            return this;
        }


        public NewsBuilder WithWeight(int weight)
        {
            _news.Weight = weight;
            return this;
        }
        public News Build()
        {
            return _news;
        }
    }
}
