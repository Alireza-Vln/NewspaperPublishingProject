using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.NewsTags;
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
        readonly DbSet<NewspaperNews> _newspaperNews;
        public EFNewsRepository(EFDataContext context)
        {
            _news = context.Newses;
            _newspaperNews = context.NewspaperNewses;
        }

        public void Add(News news)
        {
            _news.Add(news);
        }

        public void Delete(News? news)
        {
            _news.Remove(news);
        }

        public News? FindNewsByCategory(int categoryId)
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
                 .Include(_ => _.NewsTags)
                 .ThenInclude(_=>_.Tag)
                 .Include(_ => _.Author)
                 .Select(_ => new GetNewsDto
                 {
                     Id = _.Id,
                     Title = _.Title,
                     Weight = _.Weight,
                     CategoryTitle = _.Category.Title,
                     AuthorName = _.Author.FirstName+" "+ _.Author.LastName,
                     Tags= _.NewsTags.Select(_=>_.Tag.Title).ToList(),
                     View=_.View,

                 });
          


            if(filterDto.Category != null)
            {
                news = news.Where(_ => _.CategoryTitle
                .Replace(" ",string.Empty)
                .Contains(filterDto.Category));
            }
            if (filterDto.Author != null)
            {
                news = news.Where(_ => _.AuthorName
                .Replace(" ",string.Empty)
                .Contains(filterDto.Author
                .Replace(" ",string.Empty)));
            }
            return news.ToList();
        }
        public NewspaperNews? FindNewspaperByNews(int newsId)
        {
            return _newspaperNews.FirstOrDefault(_ => _.NewsId == newsId);
        }

        public News? FindNewsByTitle(string newsTitle)
        {
            return _news.FirstOrDefault(_ => _.Title == newsTitle);
        }
    }
}
