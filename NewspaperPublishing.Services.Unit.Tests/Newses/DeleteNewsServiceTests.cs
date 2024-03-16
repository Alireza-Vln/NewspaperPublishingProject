using FluentAssertions;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newses;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Newses
{
    public class DeleteNewsServiceTests : BusinessUnitTest
    {
        readonly NewsService _sut;
        public DeleteNewsServiceTests()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Delete_deletes_news_properly()
        {
            var category=new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var author=new AuthorBuilder() .Build();
            DbContext.Save(author); 
            var news=new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .Build();
            DbContext.Save(news);

            await _sut.Delete(news.Id);

            var actual = ReadContext.Newses.FirstOrDefault();
            actual.Should().BeNull();    
        }
        [Fact]
        public async Task Throw_deletes_news_that_has_been_published_exception()
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
            var newspaper=new NewspaperBuilder() 
                .Build();
            DbContext.Save(newspaper);
            var newspaperNews = new NewspaperNews()
            {
                NewsId = news.Id,
                NewspaperId = newspaper.Id
            };
            DbContext.Save(newspaperNews);

            var actual=()=>_sut.Delete(news.Id);

            await actual.Should().ThrowExactlyAsync<ThrowDeleteNewsThatHasBeenPublishedException>();

        }
        [Fact]
        public async Task Throw_deletes_news_if_news_is_null_exception()
        {
            var dummyNewsId = 544;

            var actual = () => _sut.Delete(dummyNewsId);

            await actual.Should().ThrowExactlyAsync<ThrowDeleteNewsIfNewsIsNullException>();

        }
    }
}
