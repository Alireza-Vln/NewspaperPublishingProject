using FluentAssertions;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Test.Tools.Authors.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    [Scenario("اضافه کردن نویسنده ")]
    [Story("",
    AsA = " ناشر",
    IWantTo = " نویسنده خود را اضفه کنم ",
    InOrderTo = " برای خبر هایم نوبسنده داسته باشم")]
    public class AddAuthorTest : BusinessIntegrationTest
    {
        readonly AuthorService _sut;
        public AddAuthorTest()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);
        }

        [Given(" در فهرست نویسنده ها دسته بندی  وجود ندارد")]
        private void Given()
        {

        }
        [When(" دسته بندی به اسم علیرضاو فامیل ولدان در  فهرست نویسنده ها اضافه میکنم")]
        private async Task When()
        {
            var dto =new AddAuthorDto()
            {
                FirstName = "علیرضا",
                LastName = "ولدان"
             };
            await _sut.Add(dto);
        }
        [Then(" یک دسته بندی در فهرست نویسنده ها با اسم علیرضا ولدان وجود دارد   ")]
        private void Then()
        {
            var actual = ReadContext.Authors.Single();
            actual.FirstName.Should().Be("علیرضا");
            actual.LastName.Should().Be("ولدان");
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
