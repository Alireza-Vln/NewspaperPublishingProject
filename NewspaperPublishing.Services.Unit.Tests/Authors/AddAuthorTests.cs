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
    public class AddAuthorTests :BusinessUnitTest
    {
        readonly AuthorService _sut;
        public AddAuthorTests()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Add_adds_author_properly()
        {
            var dto=AddAuthorDtoFactory.Create();
            
            _sut.Add(dto);

            var actual = ReadContext.Authors.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
        }
    }
}
