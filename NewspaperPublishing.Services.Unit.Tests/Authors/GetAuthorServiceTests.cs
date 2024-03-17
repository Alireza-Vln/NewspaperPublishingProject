using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Authors.Factories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Authors
{
    public class GetAuthorServiceTests:BusinessUnitTest
    {
        readonly AuthorService _sut;
        public GetAuthorServiceTests()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);

        }
        [Fact]
        public async Task Get_gets_author_properly()
        {
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

          var actual= await _sut.Get();

           
            actual.Single().Id.Should().Be(author.Id);
            actual.Single().FirstName.Should().Be(author.FirstName);
            actual.Single().LastName.Should().Be(author.LastName);


        }
        [Fact]
        public async Task Get_gets_author_with_the_most_news()
        {
            var category=new CategoryBuilder().Build();  
            DbContext.Save(category);
            var tag = new TagBuilder()
               .WithCategoryId(category.Id)
               .Build();
            DbContext.Save(tag);
            var author1 = new AuthorBuilder().Build();
            DbContext.Save(author1); 
            var news1=new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news1);
            var news2=new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news2);
            var news3=new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news3); 

            var actual = await _sut.GetAuthorMostNews();

            actual.Single().NewsCount.Should().Be(3);
           
        }
        [Fact]
        public async Task Get_gets_author_with_the_most_view()
        {
            var author=new AuthorBuilder()
                .WithView(6)
                .Build();
            DbContext.Save(author);

            var actual= await _sut.GetAuthorMostView();

            actual.Single().View.Should().Be(6);
        }
    }
}
