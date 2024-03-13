using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Spec.Tests.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Authors.Factories
{
   public static class AuthorAppServiceFactory
    {
        public static AuthorService Create(EFDataContext context)
        {
            return new AuthorAppService(
                new EFAuthorRepository(context),
                new EFUnitOfWork(context));
        }
    }
}
