using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newses;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Newses.Builders;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Newses
{
    public class GetNewsServiceTests :BusinessUnitTest
    {
        readonly NewsService _sut;
        public GetNewsServiceTests()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_Gets_news_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);
            var news = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .Build();
            DbContext.Save(news);

            var filter = new FiltersNewsDto();
            var actual = await _sut.Get(filter);

            actual.Single().Title.Should().Be(category.Title);
            actual.Single().AuthorName.Should()
                .Be(author.FirstName+" "+author.LastName);
            actual.Single().Id.Should().Be(news.Id);
        }
        [Fact]
        public async void Get_gets_news_filtered_by_category()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);
            var news = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .Build();
            DbContext.Save(news);
            var filter = new FilterNewsDtoBuilder()
                .WithCategory(category.Title)
                .WithAuthor(author.FirstName + " " + author.LastName)
                .Build();
            var actual= await _sut.Get(filter);
            
            actual.Single().CategoryTitle.Should().Be(category.Title);

        }
        [Fact]
        public async Task Get_gets_news_filtered_by_author()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);
            var news = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .Build();
            DbContext.Save(news);
            var filter = new FilterNewsDtoBuilder()
                .WithCategory(category.Title)
                .WithAuthor(author.FirstName+" "+author.LastName)
                .Build();
            var actual = await _sut.Get(filter);

            actual.Single().AuthorName.Should().Be(author.FirstName+" "+author.LastName);

        }
        [Fact]
        public async Task Get_gets_news_with_most_view()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);
            var news = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .WithView(20)
                .Build();
            DbContext.Save(news);

            var actual = await _sut.GetNewsMostView();

            actual.Single().View.Should().Be(20);

        }
    }
}
