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
    [Scenario("حذف نویسنده ")]
    [Story("",
    AsA = "ناشر ",
    IWantTo = " نویسنده خود را حذف",
    InOrderTo = "نویسنده را نداشته باشم ")]
    public class DeleteAuthorTest : BusinessIntegrationTest
    {
        public AuthorService _sut;
        private Author _author;
        public DeleteAuthorTest()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);
        }


        [Given("در فهرست نویسنده ها یک دسته بندی با اسم علیرضا  و فامیل ولدان  وجود دارد ")]
        private void Given()
        {
            _author=new AuthorBuilder()
                .WithFirstName("علیرضا")
                .WithLastName("ولدان")
                .Build();
            DbContext.Save(_author);
        }
        [When(" نویسنده مذکور را  حذف کنم")]
        private async Task When()
        {
            await _sut.Delete(_author.Id);
        }
        [Then(" دسته بندی در فهرست نویسنده ها وجود ندارد ")]
        private void Then()
        {
            var actual=ReadContext.Authors.FirstOrDefault(_=>_.Id==_author.Id);
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
