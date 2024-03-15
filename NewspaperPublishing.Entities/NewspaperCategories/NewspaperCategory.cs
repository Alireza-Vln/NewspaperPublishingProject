using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Entities.Newspapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Entities.NewspaperCategories
{
    public class NewspaperCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; } = null;
        public Newspaper Newspaper { get; set; }
        public int NewspaperId { get; set; }
    }
}
