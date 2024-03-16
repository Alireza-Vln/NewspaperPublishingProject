using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newspapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Persistence.EF.Newspapers
{
    public class EFNewspaperRepository : NewspaperRepository
    {
        readonly DbSet<Newspaper> _newspaper;
        readonly DbSet<NewspaperNews> _newspaperNews;
        readonly DbSet<News> _news;
       
        public EFNewspaperRepository(EFDataContext context)
        {
            _newspaper = context.Newspapers;
            _newspaperNews = context.NewspaperNewses;
           
        }

        public void Add(Newspaper newspaper)
        {
            _newspaper.Add(newspaper);
        }

        public List<GetNewspaperDto> Get(FilterNewspaperDto? filterDto)
        {
            var newspaper = _newspaper.Include(_ => _.NewspaperNews)
                .Include(_ => _.NewspaperCategories)
                .Select(_ => new GetNewspaperDto
                {
                    Id = _.Id,
                    Title = _.Title,
                    PublishTime = _.Date,
                    Categories = _.NewspaperCategories
                    .Select(_ => _.Category.Title).ToList(),
                    Tags = _.NewspaperNews
                    .SelectMany(_ => _.News.NewsTags.Select(_ => _.Tag.Title)).ToList(),
                    news = _.NewspaperNews
                    .Select(_ => _.News.Title).ToList(),
                    Weight = _.Weight,
                    AuthorName = _.NewspaperNews
                    .Select(_ => _.News.Author.FirstName + " " + _.News.Author.LastName).ToList(),

                });

            if (filterDto.Category != null)
            {
                newspaper = newspaper.Where(_ => _.Categories.Contains(filterDto.Category));
            }
            if(filterDto.Tags != null)
            {
                newspaper=newspaper.Where(_=>_.Tags.Contains(filterDto.Tags));
            }
            if(filterDto.Author != null)
            {
                newspaper = newspaper.Where(_ => _.AuthorName.Contains(filterDto.Author));
            }
            return newspaper.ToList();
            
        }
    }
}
