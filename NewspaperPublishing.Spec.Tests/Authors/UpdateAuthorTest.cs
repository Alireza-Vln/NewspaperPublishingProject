using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Test.Tools.Authors.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    [Scenario("ویرایش نویسنده ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = "نویسنده خود را ویرایش کنم  ",
    InOrderTo = "بتوانم مشخصات نویسنده را به روز کنم ")]
    public class UpdateAuthorTest : BusinessIntegrationTest
    {
        public AuthorService _sut;
        private Author _author;
        public UpdateAuthorTest()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);
        }
        [Given("در فهرست نویسنده دسته بندی با اسم علیرضا و فامیل  ولدان وجود دارد  ")]
        private void Given()
        {
            _author = new AuthorBuilder()
                .WithFirstName("علیرضا")
                .WithLastName("ولدان")
                .Build();
            DbContext.Save(_author);

        }
        [When("نویسنده ی مذکور را با اسم مهدی و فامیل احمدی ویرایش میکنم  ")]
        private async Task When()
        {
            var dto = UpdateAuthorDtoFactory
                .Create("مهدی","احمدی");
           await _sut.Update(_author.Id, dto);

        }
        [Then(" یک دسته بندی در فهرست نویسنده ها با اسم مهدی و فامیل احمدی وجود دارد ")]
        private void Then()
        {
            var actual = ReadContext.Authors.Single();
            actual.FirstName.Should().Be("مهدی");
            actual.LastName.Should().Be("احمدی");
          
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
