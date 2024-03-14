using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Spec.Tests.Authors;
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
    [Scenario("عدم اضافه کردن خبر")]
    [Story("",
           AsA = " ناشر",
          IWantTo = " خبر خود را اضافه کنم",
           InOrderTo = "خبر را منتشر کنم ")]
    public class FailedAddNewsCategoriesDoNotMatchTags : BusinessIntegrationTest
    { 
        readonly NewsService _sut;
        private Category _category;
        private Category _category2;
        private Tag _tag;
        private Tag _tag2;
        private Author _author;
        private Func<Task> _actual;
        public FailedAddNewsCategoriesDoNotMatchTags()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست خبر ها خبری وجود ندارد ")]
        [And("برچسبی به عنوان قتل در در دسته بندی جنابی وجود دارد")]
        [And("برچسبی به عنوان تکنولوژی در در دسته بندی علمی وجود دارد")]
        [And("نویسنده ای به اسم علیرضا وفامیل ولدان وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
                .WithTitle("جنایی")
                .Build();
            DbContext.Save(_category); 
            _category2 = new CategoryBuilder()
                .WithTitle("علمی")
                .Build();
            DbContext.Save(_category2);
            _tag = new TagBuilder()
                .WithCategoryId(_category.Id)
                .WithTitle("قتل")
                .Build();
            DbContext.Save(_tag);
            _tag2 = new TagBuilder()
               .WithCategoryId(_category2.Id)
               .WithTitle("تکنولوژی")
               .Build();
            DbContext.Save(_tag2);
            _author = new AuthorBuilder()
                .WithFirstName("علیرضا")
                .WithLastName("ولدان")
                .Build();
            DbContext.Save(_author);
        }
        [When(" خبری به عنوان کشته شدن داریوش مهرجویی با وزن 5 اضافه میکنیم")]
        private async Task When()
        {
            var dto = new AddNewsDto()
            {
                Title = "کشته شدن داریوش مهرجویی ",
                Weigh = 5,
                TagId = new List<int>
                {
                    _tag.Id,
                    _tag2.Id,
                }
            };
          _actual=()=> _sut.Add(_category.Id, _author.Id, dto);
        }
        [Then(" یک دسته بندی در فهرست خبر ها با عنوان کشته شدن داریوش مهرجویی با وزن 5 وجود دارد ")]
        private async Task Then()
        {
            await _actual.Should().ThrowExactlyAsync<ThrowAddNewsCategoriesDoNotMatchTagsException>();


        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When().Wait(),
                _ => Then().Wait());
        }
    }

}
