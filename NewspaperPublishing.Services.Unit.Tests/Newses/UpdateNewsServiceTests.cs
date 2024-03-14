using FluentAssertions;
using NewspaperPublishing.Services.Newes.Contracts.Exeptions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newses;
using NewspaperPublishing.Test.Tools.Categories.Builders;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig;
using NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using NewspaperPublishing.Test.Tools.Newses.Factories;
using NewspaperPublishing.Test.Tools.Tags.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Services.Unit.Tests.Newses
{
    public class UpdateNewsServiceTests :BusinessUnitTest
    {
        readonly NewsService _sut;
        public UpdateNewsServiceTests()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Update_update_news_properly()
        {
            var category = new CategoryBuilder()
                .Build();
            DbContext.Save(category);
            var tag1 = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag1);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);
            var news=new NewsBuilder()
                .WithAuthorId(author.Id)
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(news);

            var dto = UpdateNewsDtoFactory.Create();
            await _sut.Update(news.Id, dto);

            var actual = ReadContext.Newses.FirstOrDefault(_=>_.Id==news.Id);
            actual.Title.Should().Be(dto.Title);
            actual.Weight.Should().Be(dto.Weight);
        }
        [Fact]
        public async Task Throw_update_news_if_news_is_null_Exception()
        {
            var dummyId = 465;

            var dto = UpdateNewsDtoFactory.Create();
           var actual=()=>  _sut.Update(dummyId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowUpdateNewsIfNewsIsNullException>();
        }
    }
}
