using NewspaperPublishing.Services.Unit.Tests.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Newses.Builders
{
    
    public class FilterNewsDtoBuilder
    {
        private FiltersNewsDto _FilterNews;
        public FilterNewsDtoBuilder()
        {
            _FilterNews = new FiltersNewsDto()
            {
                Author = "dummy-filter-author",
                Category = "dummy-filter-author",
            };
        }
        public FilterNewsDtoBuilder WithAuthor(string name)
        {
            _FilterNews.Author=name;
            return this;
        }
        public FilterNewsDtoBuilder WithCategory(string Title)
        {
            _FilterNews.Category = Title;
            return this;
        }
        public FiltersNewsDto Build()
        {
            return _FilterNews;
        }

    }
}
