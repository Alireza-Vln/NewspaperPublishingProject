using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Services.Newspapers.Contracts.Dtos;
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
       
        public EFNewspaperRepository(EFDataContext context)
        {
            _newspaper = context.Newspapers;
            _newspaperNews = context.NewspaperNewses;
           
        }

        public void Add(Newspaper newspaper)
        {
            _newspaper.Add(newspaper);
        }

        public List<GetNewspaperDto> Get()
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

                }) ;
            return newspaper.ToList();
        }
    }
}
