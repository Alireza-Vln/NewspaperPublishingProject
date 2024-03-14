using System.ComponentModel.DataAnnotations;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public class AddNewsDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
     public int Weight { get; set; }
        [Required]
     public List<int> TagId { get; set; } 
    
    }
}

