using FluentAssertions;
using NewspaperPublishing.Services.Tags.Contracts.Exceptions;
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
    public class UpdateTagServiceTests:BusinessUnitTest
    {
        readonly TagService _sut;
        public UpdateTagServiceTests()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Update_updates_tag_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var dto = UpdateTagDtoFactory.Creat();
 
            _sut.Update(tag.Id,dto);

            var actual = ReadContext.Tags.Single();
            actual.Title.Should().Be(dto.Title);
        
        }
        [Fact]
        public async Task Throw_update_tag_if_tag_is_null_exception()
        {
            var dummyTagId = 3443;
            var dto = UpdateTagDtoFactory.Creat();

            var actual = () => _sut.Update(dummyTagId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateTagIfTagIsNullException>();
        }
    }
}
