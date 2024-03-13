using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    [Scenario("اضافه کردن برچسب ")]
    [Story("",
    AsA = "ناشر ",
    IWantTo = "برچسبهای دسته بندی  خود را اضافه کنم  ",
    InOrderTo = " برچسب دسته بندی  خود را داشته باشم")]
    public class AddTagTest:BusinessIntegrationTest
    {
        readonly TagService _sut;
        private Category _category;
        public AddTagTest()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }

        [Given("در فهرست برچسها دسته بندی  وجود ندارد ")]
        [And("دسته بندی به عنوان جنایی با وزن 20  در فهرست دسته بندی ها وجود دارد")]
        private void Given()
        {
            _category=new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(_category);

        }
        [When(" برچسب به عنوان قتل اضافه میکنم")]
        private async Task When()
        {
            var dto = new AddTagDto
            {
                Title = ("قتل"), 
            };
            
         await  _sut.Add(_category.Id,dto);


        }
        [Then(" یک دسته بندی در فهرست برچسبها با عنوان قتل وجود دارد ")]
        private void Then()
        {
            var actual = ReadContext.Tags.Single();
            actual.Title.Should().Be("قتل");
            actual.CategoryId.Should().Be(_category.Id);
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
