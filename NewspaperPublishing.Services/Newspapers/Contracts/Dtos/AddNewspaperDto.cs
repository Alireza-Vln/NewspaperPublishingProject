using NewspaperPublishing.Entities.Categories;
using System.ComponentModel.DataAnnotations;

namespace NewspaperPublishing.Spec.Tests.Newspapers
{
    public class AddNewspaperDto
    {
        [Required]
       public string Title { get; set; }
        [Required]
        public List<int> CategoryId { get; set; }
        [Required]
        public List<int> newsId { get; set; } 
       
    }
}
