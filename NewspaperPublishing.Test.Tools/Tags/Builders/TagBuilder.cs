using NewspaperPublishing.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Tags.Builders
{
   public  class TagBuilder
    {
        readonly Tag _tag;
        public TagBuilder()
        {
            _tag = new Tag()
            {
                Title = "dummy-title",
                CategoryId = 1,

            };
        }
        public TagBuilder WithTitle(string title)
        {
            _tag.Title = title;
            return this;
        }
        public TagBuilder WithCategoryId(int categoryId)
        {
            _tag.CategoryId = categoryId;
            return this;
        }
        public Tag Build()
        {
            return _tag;
        }
    }
}
