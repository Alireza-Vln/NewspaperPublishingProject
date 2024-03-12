using System.ComponentModel.DataAnnotations;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class AddCategoryDto
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public int Weight { get; set; }
    }
}
