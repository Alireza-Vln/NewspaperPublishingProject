using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Tags;
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

namespace NewspaperPublishing.Spec.Tests.Tags
{
    [Scenario("عدم اضافه کردن برچسب ")]
    [Story("",
    AsA = " ",
    IWantTo = " ",
    InOrderTo = " ")]
    public class FailedToAddTagWithDuplicateTitle : BusinessIntegrationTest
    {
        public readonly TagService _sut;
        private Category _category;
        private Tag _tag;
        private Func<Task> _actual;
        public FailedToAddTagWithDuplicateTitle()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Given(" در فهرست برچسبها یک دسته بندی با قتل  وجود دارد")]
        [And("دسته بندی به عنوان جنایی با وزن 20  در فهرست دسته بندی ها وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
                .WithTitle("جنایی")
                .Build();
            DbContext.Save(_category);
            _tag = new TagBuilder().WithTitle("قتل")
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(_tag);

        }
        [When(" یک دسته بندی با عنوان قتل  اضافه میکنیم")]
        private async Task When()
        {
            var dto = AddTagDtoFactory.Create("قتل");;
            _actual=()=> _sut.Add(_category.Id,dto);

        }
        [Then(" تنها یک دسته بندی  با  عنوان قتل در فهرست برچسبها  وجود دارد ")]
        [And(" با خطای عنوان این اسم تکراری است رخ میدهد")]
        private async Task Then()
        {
        await  _actual.Should().ThrowExactlyAsync<ThrowAddTagIsDuplicateTitleException>();
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
