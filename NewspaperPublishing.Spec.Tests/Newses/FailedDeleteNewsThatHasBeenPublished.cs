using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public class FailedDeleteNewsThatHasBeenPublished : BusinessIntegrationTest
    {
        [Scenario("عدم حذف کردن خبر ")]
        [Story("",
          AsA = " ",
          IWantTo = "خبر خود را حذف کنم  ",
          InOrderTo = "خبر را به منتشر نکنم ")]
        readonly NewsService _sut;
        private Category _category;
        private News _news;
        private Tag _tag;
        private Author _author;
        private Newspaper _newspaper;
        private NewspaperNews _newspaperNews;
        private Func<Task> _actual;
        public FailedDeleteNewsThatHasBeenPublished()
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
            _newspaper=new NewspaperBuilder() 
                .Build();
            DbContext.Save(_newspaper);
            _newspaperNews = new NewspaperNews
            {
                NewsId = _news.Id,
                NewspaperId=_newspaper.Id

            };
            _newspaper.NewspaperNews.Add(_newspaperNews);
            DbContext.Save(_newspaper);
            DbContext.Save(_newspaperNews);


        }
        [When("خبری به عنوان کشته شدن داریوش مهرجویی با وزن 5 حذف میکنیم ")]
        private async Task When()
        {
         _actual=()=> _sut.Delete(_news.Id);

        }
        [Then(" خطایی با عنوان این خبر منتشر شده است رخ  میدهد ")]
        private void Then()
        {
            _actual.Should().ThrowExactlyAsync<ThrowDeleteNewsThatHasBeenPublishedException>();
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

