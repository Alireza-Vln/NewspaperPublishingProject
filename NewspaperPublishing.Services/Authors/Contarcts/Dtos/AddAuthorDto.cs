using System.ComponentModel.DataAnnotations;

namespace NewspaperPublishing.Spec.Tests.Authors
{
    public class AddAuthorDto
    {
        [Required] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
