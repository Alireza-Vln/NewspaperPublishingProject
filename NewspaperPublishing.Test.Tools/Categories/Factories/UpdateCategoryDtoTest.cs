using NewspaperPublishing.Spec.Tests.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Categories.Factories
{
    public static class UpdateCategoryDtoFactory
    {
        public static UpdateCategoryDto Create(
            string? title = null,
            int ?weight =null)
        {

            return new UpdateCategoryDto
            {
                Title = title ?? "update-dummy-title",
                Weight =weight??  20
            };

        }
    }
}
