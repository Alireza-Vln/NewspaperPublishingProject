using FluentAssertions;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using NewspaperPublishing.Spec.Tests.Tags;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.TagsTests
{
    public class DeleteTagServiceTest :BusinessUnitTest
    {
        readonly TagService _sut;
        public DeleteTagServiceTest()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Delete_deletes_tag_properly()
        {
            var category=new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);

            _sut.Delete(tag.Id);

            var actual = ReadContext.Tags.FirstOrDefault(_ => _.Id == tag.Id);
            actual.Should().BeNull();
        }
        [Fact]
        public async Task Throw_deletes_tag_if_tag_is_null_exception()
        {
            var dummyId = 4464;

          var actual=()=>  _sut.Delete(dummyId);

            await actual.Should().ThrowExactlyAsync<ThrowDeleteTagIfTagIsNullException>();
        }
    }
}
