using NewspaperPublishing.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Services.Newspapers.Contracts.Dtos
{
    public class GetNewspaperDto
    {
        public int Id { get; set; }
        public List<string> AuthorName { get; set; }
        public List<string> Categories { get; set; }
        public List <string> Tags { get; set; }
        public List <string> news { get; set; }
        public DateTime PublishTime { get; set; }
        public string Title { get; set; }
        public int Weight { get; set; }
    }
}
