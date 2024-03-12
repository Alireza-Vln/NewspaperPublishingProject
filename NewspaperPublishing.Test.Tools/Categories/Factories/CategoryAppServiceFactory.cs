using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Spec.Tests.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Categories.Factories
{
    public static class CategoryAppServiceFactory
    {
        public static CategoryService Create(EFDataContext context)
        {
           return new CategoryAppService(new EFCategoryRepository(context), new EFUnitOfWork(context));
        } 
    }
}
