using FluentAssertions;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.CategoryTests
{
    public class DeleteCategoryServiceTest:BusinessUnitTest
    {
        readonly CategoryService _sut;
        public DeleteCategoryServiceTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public void Delete_deletes_category_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);

            _sut.Delete(category.Id);

            var actual = ReadContext.Categories.FirstOrDefault();
            actual.Should().BeNull();
        }
        [Fact]
        public async Task Throw_deletes_category_if_category_is_null_exception()
        {
            var dummyId = 154;

            var actual=()=> _sut.Delete(dummyId);

         await actual.Should().ThrowExactlyAsync<ThrowDeletesCategoryIfCategoryIsNullException>();

        }
        [Fact]
        public async Task Throw_deletes_category_if_the_category_has_news()
        {
            var category=new CategoryBuilder().Build();
            DbContext.Save(category);
            var news=new NewsBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news);

            var actual=()=>_sut.Delete(category.Id);
            
            await actual.Should().ThrowExactlyAsync<ThrowDeleteTheCategoryHasNewsException>();
        }

    }
}
