using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperNewses;
using NewspaperPublishing.Services.Authors.Contarcts.Dtos;
using NewspaperPublishing.Services.Newes.Contracts.Dtos;
using NewspaperPublishing.Services.Unit.Tests.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Services.Newes.Contracts
{
    public interface NewsRepository
    {
        void Add(News news);
        void Delete(News? news);
        News? FindNewsByCategory(int categoryId);
        News? FindNewsById(int id);
        List<GetNewsDto> Get(FiltersNewsDto dto);
        NewspaperNews? FindNewspaperByNews(int newsId);
        News? FindNewsByTitle(string newsTitle);
        List<GetNewsDto> GetNewsMostView();
    }
}
