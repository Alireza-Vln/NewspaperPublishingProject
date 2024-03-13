using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Entities.Categories
{
    public class Category
    {
        public Category()
        {
            Tags = new List<Tag>();
            News = new List<News>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public int View { get; set; }
        public List<Tag> Tags { get; set; }
        public List<News> News { get; set; }

    }
}
