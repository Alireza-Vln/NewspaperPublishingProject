using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Services.Newes.Contracts.Exeptions;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Newses;
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

namespace NewspaperPublishing.Services.Unit.Tests.Newses
{
    public class AddNewsServiceTests : BusinessUnitTest
    {
        readonly NewsService _sut;
        //private Category _category;
        //private Category _category2;
        //private Tag _tag;
        //private Tag _tag2;
        //private Author _author; 
        public AddNewsServiceTests()
        {
            _sut = NewsAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Add_adds_news_properly()
        {
            var category = new CategoryBuilder()
                .Build();
            DbContext.Save(category);
            var tag1 = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag1);
            var tag2 = new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag2);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

            var dto = new AddNewsDto()
            {
                Title = "dummy-title ",
                Weigh = 5,
                TagId = new List<int>
                {
                    tag1.Id,
                    tag2.Id,
                }
            };
            await _sut.Add(category.Id, author.Id, dto);

            var actual = ReadContext.Newses.Single();
            actual.Title.Should().Be(dto.Title);
            actual.AuthorId.Should().Be(author.Id);
            actual.CategoryId.Should().Be(category.Id);
            actual.Weight.Should().Be(dto.Weigh);
        }
        [Fact]
        public async Task Throw_add_news_categories_do_not_match_tags_exception()
        {
            var category1 = new CategoryBuilder()
                .Build();
            DbContext.Save(category1);
            var category2 = new CategoryBuilder()
                .WithTitle("test")
                .Build();
            DbContext.Save(category2);
            var tag1 = new TagBuilder()
                .WithCategoryId(category1.Id)
                .Build();
            DbContext.Save(tag1);
            var tag2 = new TagBuilder()
                .WithCategoryId(category2.Id)
                .Build();
            DbContext.Save(tag2);
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

            var dto = AddNewsDtoFactory.Create(tag1.Id, tag2.Id);
            var actual = () => _sut.Add(category1.Id, author.Id, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddNewsCategoriesDoNotMatchTagsException>();
        }
        [Fact]
        public async Task Throw_add_news_if_categories_is_null_exception()
        {
            var dummyId = 465;
            var author = new AuthorBuilder().Build();
            DbContext.Save(author);

            var dto = AddNewsDtoFactory.Create();
            var actual = () => _sut.Add(dummyId, author.Id, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddNewsIfCategoryIsNullException>();
        }
        [Fact]
        public async Task Throw_add_news_if_author_is_null_exception()
        {
            var category1 = new CategoryBuilder()
                            .Build();
            DbContext.Save(category1);
            var category2 = new CategoryBuilder()
                .WithTitle("test")
                .Build();
            DbContext.Save(category2);
            var tag1 = new TagBuilder()
                .WithCategoryId(category1.Id)
                .Build();
            DbContext.Save(tag1);
            var tag2 = new TagBuilder()
                .WithCategoryId(category2.Id)
                .Build();
            DbContext.Save(tag2);
            var dummyAuthorId = 464;

            var dto = AddNewsDtoFactory.Create(tag1.Id, tag2.Id);
            var actual = () => _sut.Add(category1.Id, dummyAuthorId, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddNewsIfAuthorIsNullException>();
        }
    }

}
