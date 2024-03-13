using FluentAssertions;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Services.Tags.Contracts.Dtos;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public class UpdateTagTest : BusinessIntegrationTest
    {
        [Scenario(" وارایش برچسب")]
        [Story("",
          AsA = " ناشر",
            IWantTo = " برچسب ها را وایرایش کنم",
            InOrderTo = " بچسبها را به روز رسانی کنم")]
        readonly TagService _sut;
        private Tag _tag;
        public UpdateTagTest()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست برچسها دسته بندی با عنوان قتل وجود دارد ")]
        [And("دسته بندی به عنوان جنایی با وزن 20  در فهرست دسته بندی ها وجود دارد")]
        private void Given()
        {
            var category=new CategoryBuilder()
                .WithTitle("جنایی")
                .Build();
            DbContext.Save(category);
            _tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(_tag);
        }
        [When("برچسب به عنوان قتل را با عنوان سرقت ویرایش میکنم ")]
        private async Task When()
        {
            var dto = new UpdateTagDto()
            {
                Title = "سرقت"
            };
            await _sut.Update(_tag.Id,dto);
        }
        [Then(" یک دسته بندی در فهرست برچسبها با عنوان سرقت وجود دارد ")]
        private void Then()
        {
            var actual = ReadContext.Tags.Single(_=>_.Id==_tag.Id);
            actual.Title.Should().Be("سرقت");

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
