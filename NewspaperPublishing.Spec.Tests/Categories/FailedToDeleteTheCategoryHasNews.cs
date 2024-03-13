using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    [Scenario("عدم حذف دسته بندی ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " دسته بندی خود را حذف کنم",
    InOrderTo = "بتوانم دسته بندی خود را حذف کنم ")]
    public class FailedToDeleteTheCategoryHasNews: BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        private News news;
        private Category category;
        private Func<Task> _actual;
        public FailedToDeleteTheCategoryHasNews()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست دسته بندی ها یک دسته بندی با عنوان جنایی و وزن  20   وجود دارد  ")]
        [And("خبری با دسته بندی مذکور منتشر شده است  ")]
        private void Given()
        {
            category = new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(category);
            news=new NewsBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news);

        }
        [When("دسته بندی مذکور را حذف کنم ")]
        private async Task When()
        {
            _actual = () => _sut.Delete(category.Id);
        }
        [Then(" خطای با عنوان این دسته بندی درفهرست خبرها است رخ میدهد ")]
        private async Task Then()
        {
          await   _actual.Should().ThrowExactlyAsync<ThrowDeleteTheCategoryHasNewsException>();
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
