using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.NewspaperCategories;
using NewspaperPublishing.Entities.Newspapers;
using NewspaperPublishing.Entities.Tags;

namespace NewspaperPublishing.Entities.Categories
{
    public class Category
    {
        public Category()
        {
            Tags = new ();
            News = new ();
            NewspaperCategories=new ();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
        public int View { get; set; }
        public HashSet<Tag> Tags { get; set; }
        public HashSet<News> News { get; set; }
        public HashSet<NewspaperCategory> NewspaperCategories { get; set; }


    }
}
