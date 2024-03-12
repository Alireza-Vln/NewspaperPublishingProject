using FluentAssertions;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Test.Tools.Categories.Factories;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.CategoryTests
{
    public class AddCategoryServiceTest : BusinessUnitTest
    {
        readonly CategoryService _sut;
        public  AddCategoryServiceTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Add_addS_category_properly()
        {
            var dto = AddCategoryDtoFactory.Create();

             await _sut.Add(dto);

            var actual = ReadContext.Categories.Single();
            actual.Title.Should().Be(dto.Title);
            actual.Weight.Should().Be(dto.Weight);

        }
    }
}
