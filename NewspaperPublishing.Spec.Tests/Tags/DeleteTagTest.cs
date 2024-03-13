using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Tags;
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

namespace NewspaperPublishing.Spec.Tests.Tags
{
    [Scenario(": حذف کردن برچسب ")]
    [Story("",
          AsA = " ناشر",
         IWantTo = " برچستهای خودرا حذف کنم",
          InOrderTo = "تا برچسب ان دسته بندی را نداشته باشم ")]
    public class DeleteTagTest : BusinessIntegrationTest
    {

        readonly TagService _sut;
        private Category _category;
        private Tag _tag;
        public DeleteTagTest()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست برچسها دسته بندی با عنوان قتل وجود دارد ")]
        [And("دسته بندی به عنوان جنایی با وزن 20  در فهرست دسته بندی ها وجود دارد")]
        private void Given()
        {
            _category=new CategoryBuilder()
                .WithTitle("جنایی").Build();
            DbContext.Save(_category);
            _tag=new TagBuilder()
                .WithTitle("قتل")
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(_tag);

        }
        [When("برچسب به عنوان قتل حذف میکنم ")]
        private async Task When()
        {
            await _sut.Delete(_tag.Id);
        }
        [Then(" دسته بندی در فهرست برچسبها وجود ندارد ")]
        private void Then()
        {
            var actual = ReadContext.Tags.FirstOrDefault();
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
