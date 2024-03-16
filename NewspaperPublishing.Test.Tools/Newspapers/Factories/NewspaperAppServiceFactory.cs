using Moq;
using NewspaperPublishing.Contracts.Interfaces;
using NewspaperPublishing.Infrastructure;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Persistence.EF.Newses;
using NewspaperPublishing.Persistence.EF.Newspapers;
using NewspaperPublishing.Spec.Tests.Authors;
using NewspaperPublishing.Spec.Tests.Categories;
using NewspaperPublishing.Spec.Tests.Newspapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Newspapers.Factories
{
    public static class NewspaperAppServiceFactory
    {
      
        public static NewspaperAppService Create
            (EFDataContext context,
            DateTime? fakeTime=null)
            
        {
            var dateTimeServiceMock=new Mock<DateTimeService>();
            dateTimeServiceMock.Setup(_ => _.Now())
                .Returns(fakeTime ?? new DateTime(2023, 10, 10));
            return new NewspaperAppService(new EFNewspaperRepository(context),
                new EFUnitOfWork(context),
                dateTimeServiceMock.Object,
                new EFNewsRepository(context),
                new EFCategoryRepository (context),
                new EFAuthorRepository(context));
        }
    }
}
