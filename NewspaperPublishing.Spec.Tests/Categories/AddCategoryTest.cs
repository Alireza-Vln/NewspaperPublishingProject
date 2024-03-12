using FluentAssertions;
using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    [Scenario("اضافه کردن دسته بندی ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " دسته بندی اضافه کنم",
    InOrderTo = " دسته بندی رد روزنامه داشته باشم")]

    public class AddCategoryTest : BusinessIntegrationTest
    {
        readonly CategoryService _sut;
        public AddCategoryTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }


        [Given("در فهرست دسته بندی ها هیچ دسته بندی وجود ندارد ")]
        private void Given()
        {

        }
        [When("یک دسته بندی با عنوان جنایی و وزن  20   اضافه میکنیم ")]
        private async Task When()
        {
            var dto = new AddCategoryDto()
            {
                Title = "جنایی",
                Weight = 20,
            };
           await _sut.Add(dto);

        }
        [Then(" تنها یک دسته بندی  با  جنایی و وزن20 در فهرست دسته بندی ها وجود دارد ")]
        private void Then()
        {
            var actual = ReadContext.Categories.Single();
            actual.Title.Should().Be("جنایی");
            actual.Weight.Should().Be(20);

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
