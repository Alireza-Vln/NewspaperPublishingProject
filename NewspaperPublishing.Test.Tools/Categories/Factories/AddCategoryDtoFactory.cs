using NewspaperPublishing.Spec.Tests.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Categories.Factories
{
   public static class AddCategoryDtoFactory
    {
        public static AddCategoryDto Create (string ? title=null)
        {

            return new AddCategoryDto
            {
                Title = title??"dummy-title",
                Weight = 20
            };
        
        }
    }
}
