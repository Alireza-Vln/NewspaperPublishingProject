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
    [Scenario("عدم اضافه کردن دسته بندی ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " دسته بندی اضافه کنم",
    InOrderTo = " دسته بندی رد روزنامه داشته باشم")]

    public class FailedToAddCategoryWithDuplicateTitle:BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        private Category _category;
        private Func<Task> _actual;
        public FailedToAddCategoryWithDuplicateTitle()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست دسته بندی ها یک دسته بندی با عنوان جنایی و وزن  20   وجود دارد ")]
        private void Given()
        {
            _category =new CategoryBuilder()
                .WithTitle("جنایی")
                .Build();
            DbContext.Save(_category);
        }
        [When(" یک دسته بندی با عنوان جنایی و وزن  20   اضافه میکنیم")]
        private async Task When()
        {
            var dto = AddCategoryDtoFactory.Create("جنایی");
            _actual = () => _sut.Add(dto);
        }
        [Then(" تنها یک دسته بندی  با  جنایی و وزن20 در فهرست دسته بندی ها وجود دارد ")]
        [And(" خطای با عنوان این اسم تکراری است رخ میدهد")]
        private async Task Then()
        {
            await _actual.Should().ThrowExactlyAsync<ThrowAddCategoryIsDuplicateTitleException>();
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
