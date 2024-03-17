using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Tags;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.TagsTests
{
    public class GetTagServiceTests:BusinessUnitTest
    {
        readonly TagService _sut;
        public GetTagServiceTests()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Get_gets_tag_properly()
        {
            var category=new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);

            var actual=await _sut.Get();
            actual.Single().Id.Should().Be(tag.Id);
            actual.Single().Title.Should().Be(tag.Title);
            actual.Single().CategoryTitle.Should().Be(category.Title);

        }
    }
}
