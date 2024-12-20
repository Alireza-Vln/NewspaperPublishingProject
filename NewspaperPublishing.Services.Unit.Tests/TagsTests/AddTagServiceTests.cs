﻿using FluentAssertions;
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
       
        public AddTagServiceTests()
        {
            _sut = TagAppServiceFactory.Create(SetupContext);
        }
        [Fact]
        public async Task Add_adds_tag_properly()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var dto = AddTagDtoFactory.Create();

           await _sut.Add(category.Id, dto);

            var actual = ReadContext.Tags.Single(_=>_.CategoryId==category.Id);
            actual.Title.Should().Be(dto.Title);
            actual.CategoryId.Should().Be(category.Id);
        }
        [Fact]
        public async Task Throw_add_tag_is_duplicate_title_exception()
        {
            var category = new CategoryBuilder().Build();
            DbContext.Save(category);
            var tag=new TagBuilder()
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(tag);
            var dto=AddTagDtoFactory.Create(tag.Title);

            var actual=()=> _sut.Add(category.Id, dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddTagIsDuplicateTitleException>();
        }
        [Fact]
        public async Task Throw_add_tag_if_category_is_null_exception()
        {
            var dummyId = 454;
            var dto = AddTagDtoFactory.Create();

          var actual=()=> _sut.Add(dummyId,dto);

         await   actual.Should().ThrowExactlyAsync<ThrowAddTagIfCategoryIsNullException>();

        }
    }
}
