using NewspaperPublishing.Entities.Newses;
using NewspaperPublishing.Entities.Newspapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Entities.NewspaperNewses
{
   public class NewspaperNews
    {
        public int Id { get; set; } 
        public News News { get; set; }
        public int NewsId { get; set; }
        public Newspaper Newspaper { get; set; }
        public int NewspaperId { get; set; }
    }
}
