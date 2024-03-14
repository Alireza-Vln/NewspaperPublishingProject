using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts;
using NewspaperPublishing.Services.Newes.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.Newses
{
    public class EFNewsRepository : NewsRepository
    {
        readonly DbSet<News> _news;
        public EFNewsRepository(EFDataContext context)
        {
            _news = context.Newses;
        }

        public void Add(News news)
        {
            _news.Add(news);
        }

        public void Delete(News? news)
        {
            _news.Remove(news);
        }

        public News? FindCategoryByNews(int categoryId)
        {
           return _news.FirstOrDefault(_=>_.CategoryId == categoryId);
        }

        public News? FindNewsById(int id)
        {
            return _news?.FirstOrDefault(_=>_.Id == id);
        }

        public List<GetNewsDto> Get(FiltersNewsDto filterDto)
        {
            var news = _news.Include(_ => _.Category)
                 .ThenInclude(_ => _.Tags).Include(_ => _.Author)
                 .Select(_ => new GetNewsDto
                 {
                     Id = _.Id,
                     Title = _.Title,
                     CategoryTitle = _.Category.Title,
                     AuthorName = _.Author.LastName,
                     Tags = _.Category.Tags.Select(_ => _.Title).ToList()

                 });
            if(filterDto.Category != null)
            {
                news = news.Where(_ => _.CategoryTitle == filterDto.Category);
            }
            if (filterDto.Author != null)
            {
                news = news.Where(_ => _.AuthorName == filterDto.Author);
            }
            return news.ToList();
        }
    }
}
