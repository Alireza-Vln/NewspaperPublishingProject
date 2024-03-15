using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Entities.NewsTags
{
    public class NewsTag
    {
        public int Id { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public News News { get; set; }  
        public int NewsId { get; set; }
    }
}
