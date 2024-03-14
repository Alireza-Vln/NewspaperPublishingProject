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
    public class UpdateAuthorServiceTests:BusinessUnitTest
    {
        readonly AuthorService _sut;
        public UpdateAuthorServiceTests()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);

        }
        [Fact]
        public void Update_updates_author_properly()
        {
            var author=new AuthorBuilder().Build();
            DbContext.Save(author);
            var dto = UpdateAuthorDtoFactory.Create();

            _sut.Update(author.Id, dto);

            var actual = ReadContext.Authors.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
        }
        [Fact]
        public async Task Throw_update_author_if_author_is_null_exception()
        {
            var dummyId = 354;
            var dto = UpdateAuthorDtoFactory.Create();

            var actual = () => _sut.Update(dummyId,dto);


            await actual.Should().ThrowExactlyAsync<ThrowUpdatesAuthorIfAuthorIsNullException>();
        }
    }
}
