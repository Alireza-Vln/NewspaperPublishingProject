using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
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
        News? FindCategoryByNews(int categoryId);
        News? FindNewsById(int id);
    }
}
