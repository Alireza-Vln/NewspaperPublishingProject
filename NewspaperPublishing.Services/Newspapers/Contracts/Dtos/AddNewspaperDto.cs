using NewspaperPublishing.Entities.Categories;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public class AddNewspaperDto
    {
       public string Title { get; set; }
        public List<int> CategoryId { get; set; }
        public List<int> newsId { get; set; } 
       
    }
}
