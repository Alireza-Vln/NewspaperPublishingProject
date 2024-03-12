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
using static NewspaperPublishing.Spec.Tests.Categories.UpdateCategoryTest;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    [Scenario("ویرایش دسته بندی ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " دسته بندی را ویرایش کنم",
    InOrderTo = " دسته بندی خود را ویرایش کنم")]

    public partial class UpdateCategoryTest :BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        private Category _category;
        public UpdateCategoryTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }

        [Given(" در فهرست دسته بندی ها یک دسته بندی با عنوان جنایی و وزن  20   وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(_category);
        }
        [When(" دسته بندی مذکور را  با عنوان حوادث و وزن  30   تغییر میدهیم")]
        private async Task When()
        {
            var dto = UpdateCategoryDtoFactory.Create("حوادث",30);

            await _sut.Update(_category.Id, dto);
         
        }
        [Then(" تنها یک دسته بندی  با  عنوان حوادث  و وزن  30 در فهرست دسته بندی ها وجود دارد ")]
        private void Then()
        {
            var actual=ReadContext.Categories.Single(_=>_.Id==_category.Id);
            actual.Title.Should().Be("حوادث");
            actual.Weight.Should().Be(30);
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
