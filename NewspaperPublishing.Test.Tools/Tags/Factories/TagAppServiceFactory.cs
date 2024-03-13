using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Spec.Tests.Categories;

namespace NewspaperPublishing.Spec.Tests.Tags
{
    public static class TagAppServiceFactory
    {
        public static TagService Create(EFDataContext context)
        { 
        return new TagAppService(
          new EFTagRepository(context),
           new EFUnitOfWork(context),
            new EFCategoryRepository(context));
        
        }
    }
}
