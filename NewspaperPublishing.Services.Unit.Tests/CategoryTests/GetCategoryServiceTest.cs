using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Tags.Builders;

using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.CategoryTests
{
    public class GetCategoryServiceTest:BusinessUnitTest
    {
        readonly CategoryService _sut;
        public GetCategoryServiceTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_gets_category_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);

           var actual=await _sut.GetAll();

            actual.Single().Title.Should().Be(category.Title);
            actual.Single().Weight.Should().Be(category.Weight);
            actual.Single().View.Should().Be(category.View);
            
           
        }
        [Fact]
        public async Task Get_gets_category_with_most_News()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
               .WithCategoryId(category.Id)
               .Build();
            DbContext.Save(tag);
            var author1 = new AuthorBuilder().Build();
            DbContext.Save(author1);
            var news1 = new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news1);
            var news2 = new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news2);
            var news3 = new NewsBuilder()
                .WithAuthorId(author1.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news3);

            var actual = await _sut.GetCategoryMostNews();

            actual.Single().NewsCount.Should().Be(3);
        }
        [Fact]
        public async Task Get_gets_category_with_most_view()
        {
            var category1 = new CategoryBuilder()
                .WithView(6)
                .Build();
            DbContext.Save(category1);

            var actual = await _sut.GetCategoryMostView();

            actual.Single().View.Should().Be(category1.View=6);
        }
    }
}
