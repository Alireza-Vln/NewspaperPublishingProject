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
    [Scenario(" عدم ویرایش دسته بندی ")]
    [Story("",
   AsA = " ناشر",
   IWantTo = " دسته بندی را ویرایش کنم",
   InOrderTo = " دسته بندی خود را ویرایش کنم")]
    public class FailedToUpdateCategoryWithDuplicateTitle : BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        private Category _category;
        private Category _category2;
        private Func<Task> _actual;

        public FailedToUpdateCategoryWithDuplicateTitle()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }

        [Given(" در فهرست دسته بندی ها یک دسته بندی با عنوان جنایی و وزن  20   وجود دارد")]
        [And("دسته بندی با عنوان علمی با وزن 30 وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(_category);
            _category2=new CategoryBuilder()
                .WithTitle("علمی")
                .WithWeight(30)
                .Build();
            DbContext.Save(_category2);
        }
        [When(" دسته بندی با عنوان علمی با وزن 30 را  با عنوان جنایی و وزن 20   تغییر میدهیم")]
        private async Task When()
        {
            var dto = UpdateCategoryDtoFactory.Create("جنایی", 20);

            _actual=()=> _sut.Update(_category.Id, dto);

        }
        [Then(" تنها یک دسته بندی  با  عنوان حوادث  و وزن  30 در فهرست دسته بندی ها وجود دارد ")]
        private async Task Then()
        {
            await _actual.Should().ThrowExactlyAsync<ThrowUpdateCategoryIsDuplicateTitleException>();
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

