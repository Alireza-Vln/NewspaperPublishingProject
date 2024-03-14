using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
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
    public class DeleteAuthorTests :BusinessUnitTest
    {
        readonly AuthorService _sut;
        public DeleteAuthorTests()
        {
            _sut = AuthorAppServiceFactory.Create(SetupContext);

        }
        [Fact]
        public void Delete_deletes_author_properly()
        {
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

            _sut.Delete(author.Id);

            var actual = ReadContext.Authors.FirstOrDefault(_ => _.Id == author.Id);
            actual.Should().BeNull();


        }
        [Fact]
        public void Throw_deletes_author_if_author_is_null_exception()
        {
            var dummyId = 354;

           var actual=()=> _sut.Delete(dummyId);


            actual.Should().ThrowExactlyAsync<ThrowDeletesAuthorIfAuthorIsNullException>();
        }
    }
}
