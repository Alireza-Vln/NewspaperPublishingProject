using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    [Scenario("حذف کردن خبر ")]
    [Story("",
     AsA = " ",
    IWantTo = "خبر خود را حذف کنم  ",
     InOrderTo = "خبر را به منتشر نکنم ")]
    public class DeleteNewsTest : BusinessIntegrationTest
    {
        readonly NewsService _sut;
        private Category _category;
        private News _news;
        private Tag _tag;
        private Author _author;
        public DeleteNewsTest()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }

        [Given("در فهرست خبر ها خبری  با عنوان کشته شدن داریوش مهرجویی با وزن 5 وجود دارد ")]
        [And("برچسبی به عنوان قتل در در دسته بندی جنابی وجود دارد")]
        [And("نویسنده ای به اسم علیرضا وفامیل ولدان وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
               .WithTitle("جنایی")
               .Build();
            DbContext.Save(_category);
            _tag = new TagBuilder()
                .WithCategoryId(_category.Id)
                .WithTitle("قتل")
                .Build();
            DbContext.Save(_tag);
            _author = new AuthorBuilder()
                .WithFirstName("علیرضا")
                .WithLastName("ولدان")
                .Build();
            DbContext.Save(_author);
            _news = new NewsBuilder()
                .WithCategoryId(_category.Id)
                .WithAuthorId(_author.Id)
                .WithWeight(10)
                .Build();
            DbContext.Save(_news);
        }
        [When("خبری به عنوان کشته شدن داریوش مهرجویی با وزن 5 حذف میکنیم ")]
        private async Task When()
        {
            await _sut.Delete(_news.Id);
        }
        [Then(" دسته بندی با فهرست خبر ها  وجود ندارد ")]
        private void Then()
        {
            var actual = ReadContext.Newses.FirstOrDefault();
            actual.Should().BeNull();
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then());
        }



    }
}
