using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Persistence.EF.Newses;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Tags;

namespace NewspaperPublishing.Spec.Tests.Newses
{
    public static class NewsAppServiceFactory 
    {
        public static NewsAppService Create(EFDataContext context)
        {
            return new NewsAppService
                (new EFNewsRepository(context),
                new EFUnitOfWork(context),
                new EFCategoryRepository(context),
                new EFAuthorRepository(context),
                new EFTagRepository(context),
                new EFNewspaperRepository(context)
                );
        }
    }
}
