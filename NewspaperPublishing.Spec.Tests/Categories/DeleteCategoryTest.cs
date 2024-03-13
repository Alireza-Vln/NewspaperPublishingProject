using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    [Scenario("حذف دسته بندی ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " دسته بندی خود را حذف کنم",
    InOrderTo = "بتوانم دسته بندی خود را حذف کنم ")]
    public class DeleteCategoryTest:BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        private Category category;
        public DeleteCategoryTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }

        [Given("در فهرست دسته بندی ها یک دسته بندی با عنوان جنایی و وزن  20   وجود دارد ")]
        private void Given()
        {
            category = new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(category);
        }
        [When("دسته بندی مذکور را  حذف کنم ")]
        private async Task When()
        {
           await _sut.Delete(category.Id);
        }
        [Then(" دسته بندی در فهرست دسته بندی وجود ندارد ")]
        private void Then()
        {
            var actual=ReadContext.Categories.FirstOrDefault();
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
