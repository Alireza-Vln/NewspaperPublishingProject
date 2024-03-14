using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Test.Tools.Authors.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Authors
{
    public class GetAuthorServiceTests:BusinessUnitTest
    {
        readonly AuthorService _sut;
        public GetAuthorServiceTests()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);

        }
        [Fact]
        public async Task Get_gets_author_properly()
        {
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

          var actual= await _sut.Get();

           
            actual.Single().Id.Should().Be(author.Id);
            actual.Single().FirstName.Should().Be(author.FirstName);
            actual.Single().LastName.Should().Be(author.LastName);


        }
    }
}
