﻿using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Services.Newes.Contracts;
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

        public News? FindCategoryByNews(int categoryId)
        {
           return _news.FirstOrDefault(_=>_.CategoryId == categoryId);
        }
    }
}