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
    public class GetCategoryServiceTest:BusinessUnitTest
    {
        readonly CategoryService _sut;
        public GetCategoryServiceTest()
        {
            _sut = CategoryAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async void Get_gets_category_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);

           var actual=await _sut.GetAll();

            actual.Single().Title.Should().Be(category.Title);
            actual.Single().Weight.Should().Be(category.Weight);
            actual.Single().View.Should().Be(category.View);
            actual.Single().NewspaperId.Should().Be(category.NewspaperId);
           
        }
    }
}
