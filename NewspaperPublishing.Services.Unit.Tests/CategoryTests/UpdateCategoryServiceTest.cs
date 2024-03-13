using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;

using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.CategoryTests
{
    public class UpdateCategoryServiceTest : BusinessUnitTest
    {
        readonly CategoryService _sut;
        public UpdateCategoryServiceTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Update_updates_Category_properly()
        {
            var category=new CategoryBuilder().Build();
            DbContext.Save(category);
            var dto = UpdateCategoryDtoFactory.Create();

            _sut.Update(category.Id, dto);

            var actual = ReadContext.Categories.Single(_ => _.Id == category.Id);
            actual.Title.Should().Be(dto.Title);
            actual.Weight.Should().Be(dto.Weight);
        }
        [Fact]
        public async Task Throw_update_Category_is_duplicate_title_exception()
        {
            var category = new CategoryBuilder()
                .WithTitle("test")
                .Build();
            DbContext.Save(category);
            var category2 = new CategoryBuilder()
                .WithTitle("test2")
                .Build();
            
            DbContext.Save(category2);
            var dto = UpdateCategoryDtoFactory.Create("test");

            var actual = () => _sut.Update(category2.Id,dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateCategoryIsDuplicateTitleException>();
        }
        [Fact]
        public async Task Throw_update_Category_if_category_is_null_exception()
        {
            var dummyId = 15245;
            var dto = UpdateCategoryDtoFactory.Create("test");

            var actual = () => _sut.Update(dummyId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateCategoryIfCategoryIsNullException>();
        }
    }
}
