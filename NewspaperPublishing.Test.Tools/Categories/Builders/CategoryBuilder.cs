using NewspaperPublishing.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Categories.Builders
{
    public class CategoryBuilder
    {
        readonly Category _category;
        public CategoryBuilder()
        {
            _category = new Category()
            {
                Title = "dummy-title",
                Weight = 20,
            };
        }
        public CategoryBuilder WithTitle(string title)
        { 
        
        _category.Title = title;
            return this;
        
        }
        public CategoryBuilder WithWeight(int weight)
        {
            _category.Weight = weight;
            return this;
        }
        public Category Build()
        { 
        return _category;
        }
    }
}
