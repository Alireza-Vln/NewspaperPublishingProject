using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Services.Unit.Tests.Newses;
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
    public class AddNewspaperServiceTests : BusinessUnitTest
    {
        readonly NewspaperService _sut;
        private DateTime _fakeTime;
        public AddNewspaperServiceTests()
        {
            _sut = NewspaperAppServiceFactory.Create(SetupContext, _fakeTime);
        }
        [Fact]
        public async Task Add_adds_newspaper_properly()
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

            var dto = new AddNewspaperDto()
            {
                Title = "Title",
                CategoryId = new List<int>
                {
                    category.Id
                },
                newsId = new List<int>
                {
                    news1.Id,
                    news2.Id,
                    news3.Id,
                    news4.Id,
                }
            };

            await _sut.Add(dto);

            var actual = ReadContext.Newspapers.Single();
            actual.Title.Should().Be(dto.Title);
            actual.Weight.Should().Be(20);
            actual.Date.Should().Be(_fakeTime);
        }
        [Fact]
        public async void Throw_add_newspaper_the_weight_of_the_news_category_has_not_reached_the_quorum_exception()
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
            var dto = new AddNewspaperDto()
            {
                Title = "Title",
                CategoryId = new List<int>
                {
                    category.Id
                },
                newsId = new List<int>
                {
                    news1.Id,
                    news2.Id,
                    news3.Id,

                }
            };

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddNewspaperTheWeightOfTheNewsCategoryHasNotReachedTheQuorumException>();
        }
        [Fact]
        public async Task Throw_adds_newspaper_if_category_is_null_exception()
        {
            var dummyCategoryId = 1454;
            var category = new CategoryBuilder()
              .WithWeight(20)
              .Build();
            DbContext.Save(category);
            var tag = new TagBuilder()
              .WithCategoryId(category.Id)
              .WithTitle("test1")
              .Build();
            DbContext.Save(tag);
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
            var dto = new AddNewspaperDto()
            {
                Title = "Title",
                CategoryId = new List<int>
                {

                    dummyCategoryId,
                    category.Id,
                },
                newsId = new List<int>
                {
                    news1.Id,
                    news2.Id,
                    news3.Id,
                    news4.Id,

                }
            };

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsNewspaperIfCategoryIsNullException>();
        }
        [Fact]
        public async Task Throw_adds_newspaper_if_news_is_null_exception()
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

            var dummyIdNews = 54654;
            var dto = new AddNewspaperDto()
            {
                Title = "Title",
                CategoryId = new List<int>
          {
              category.Id
          },
                newsId = new List<int>
          {
             dummyIdNews,

          }
            };

            var actual = () => _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsNewspaperIfNewsIsNullException>();
        }

    }
}
