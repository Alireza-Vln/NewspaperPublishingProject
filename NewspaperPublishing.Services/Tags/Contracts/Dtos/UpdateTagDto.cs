using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Services.Tags.Contracts.Dtos
{
    public class UpdateTagDto
    {
        [Required]
        public string Title { get; set; }
    }
}
