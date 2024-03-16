using FluentAssertions;
using NewspaperPublishing.Entities.Authors;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Tags;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
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

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public class FailedAddNewspaperTheWeightOfTheNewsCategoryHasNotReachedTheQuorum:BusinessUnitTest
    {
        readonly NewspaperService _sut;
        private DateTime _fakeTime;
        private Category _category;
        private Tag _tag1;
        private Tag _tag2;
        private News _news1;
        private News _news2;
        private News _news3;
        private Author _author;
        private Func<Task> _actual;
        public FailedAddNewspaperTheWeightOfTheNewsCategoryHasNotReachedTheQuorum()
        {
            _sut = NewspaperAppServiceFactory.Create(SetupContext, _fakeTime);
        }
        [Given(" در فهرست روزنامه ها روزنامه ای وجود ندارد")]
        [And("برچسبی به عنوان قتل در در دسته بندی جنابی با وزن20 وجود دارد")]
        [And("برچسبی به عنوان سرقت در در دسته بندی جنابی  با وزن 20 وجود دارد")]
        [And("خبری به عنوان کشته شدن داریوش مهرجویی با وزن 5  وجود دارد")]
        [And("خبری به عنوان کشته شدن مردی در کوچه با وزن 5  وجود دارد")]
        [And("خبری به عنوان دزدی از زنی باردار با وزن 5  وجود دارد")]
        [And("با نویسندگی علیر ضا ولدان وجود دارد")]
        private void Given()
        {
            _category = new CategoryBuilder()
                .WithTitle("جنایی")
                .WithWeight(20)
                .Build();
            DbContext.Save(_category);
            _tag1 = new TagBuilder()
                .WithTitle("سرقت")
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(_tag1);
            _tag2 = new TagBuilder()
                .WithTitle("قتل")
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(_tag2);
            _author = new AuthorBuilder()
                .WithFirstName("علیرضا")
                .WithLastName("ولدان")
                .Build();
            DbContext.Save(_author);
            _news1 = new NewsBuilder()
                .WithTitle("کشته شدن داریوش مهرجویی")
                .WithWeight(5)
                .WithCategoryId(_category.Id)
                .WithAuthorId(_author.Id)
                .Build();
            DbContext.Save(_news1);
            _news2 = new NewsBuilder()
                .WithTitle("کشته شدن مردی در کوچه")
                .WithWeight(5)
                .WithCategoryId(_category.Id)
                .WithAuthorId(_author.Id)
                .Build();
            DbContext.Save(_news2);
            _news3 = new NewsBuilder()
                .WithTitle("دزدی از پسری 15 ساله")
                .WithWeight(5)
                .WithCategoryId(_category.Id)
                .WithAuthorId(_author.Id)
                .Build();
            DbContext.Save(_news3);

        }
        [When("خبرهای مذکور با عنوان خبر فارس با تاریخ امروز را منتشر  میکنیم ")]
        private void When()
        {
            var dto = new AddNewspaperDto()
            {
                Title = "خبر فارس",
                newsId = new List<int>
                {
                    _news1.Id,
                    _news2.Id,
                    _news3.Id,
                },
                CategoryId = new List<int>
                {
                    _category.Id,
                }
            };
          _actual= ()=> _sut.Add(dto);
        }
        [Then(" یک دسته بندی با خبرهای مذکور و تاریخ امروز با وزن 20 داریم  ")]
        private async Task Then()
        {
            await _actual.Should().ThrowExactlyAsync<ThrowAddNewspaperTheWeightOfTheNewsCategoryHasNotReachedTheQuorumException>();
           
        }
        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When(),
                _ => Then().Wait());
        }
    }
}
