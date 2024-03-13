using FluentAssertions;
using NewspaperPublishing.Entities.Categories;
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
    public class AddTagServiceTests : BusinessUnitTest
    {
        readonly TagService _sut;
        private Category _category;
        public AddTagServiceTests()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Add_add_tag_properly()
        {
            _category = new CategoryBuilder().Build();
            DbContext.Save(_category);
            var dto = AddTagDtoFactory.Create("test");

           await _sut.Add(_category.Id, dto);

            var actual = ReadContext.Tags.Single();
            actual.Title.Should().Be(dto.Title);
            actual.CategoryId.Should().Be(_category.Id);
        }
        [Fact]
        public async Task Throw_add_tag_is_duplicate_title_exception()
        {
            _category = new CategoryBuilder().Build();
            DbContext.Save(_category);
            var tag=new TagBuilder()
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(tag);
            var dto=AddTagDtoFactory.Create(tag.Title);

            var actual=()=> _sut.Add(_category.Id, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddTagIsDuplicateTitleException>();
        }
        [Fact]
        public async Task Throw_add_tag_if_category_is_null_exception()
        {
            var dummiId = 454;
            var dto = AddTagDtoFactory.Create();

          var actual=()=> _sut.Add(dummiId, dto);

         await   actual.Should().ThrowExactlyAsync<ThrowAddTagIfCategoryIsNullException>();

        }
    }
}
