using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newspapers;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Newspapers.Factories;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Newspapers
{
    public class GetNewspaperServiceTests : BusinessUnitTest
    {
        readonly NewspaperService _sut;
        private DateTime _fakeTime;
        public GetNewspaperServiceTests()
        {
            _sut = NewspaperAppServiceFactory.Create(SetupContext, _fakeTime);
        }
        [Fact]
        public async Task Get_Gets_newspaper_properly()
        {
            var category = new CategoryBuilder()
                .WithWeight(20)
                .Build();
            DbContext.Save(category);

            var tag1 = new TagBuilder()
                .WithCategoryId(category.Id)
                .WithTitle("test1")
                .Build();
            DbContext.Save(tag1);
            var tag2 = new TagBuilder()
                .WithCategoryId(category.Id)
                .WithTitle("test2")
                .Build();
            DbContext.Save(tag2);
            var author = new AuthorBuilder()
                .Build();
            DbContext.Save(author);
            var news1 = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .WithWeight(5)
                .Build();
            DbContext.Save(news1);
            var news2 = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .WithWeight(5)
                .Build();
            DbContext.Save(news2);
            var news3 = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .WithWeight(5)
                .Build();
            DbContext.Save(news3);
            var news4 = new NewsBuilder()
                .WithCategoryId(category.Id)
                .WithAuthorId(author.Id)
                .WithWeight(5)
                .Build();
            DbContext.Save(news4);
            var newpaper = new Newspaper()
            {
                Title = "Title",
                Weight = 20,
                Date = _fakeTime,

            };
            DbContext.Save(newpaper);

            var filter = new FilterNewspaperDto();
            await _sut.Get(filter);

            var actual = ReadContext.Newspapers.Single();
            actual.Title.Should().Be(newpaper.Title);
            actual.Weight.Should().Be(newpaper.Weight);
            actual.Date.Should().Be(newpaper.Date);
        }
    }
}
