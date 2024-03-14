using NewspaperPublishing.Spec.Tests.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperPublishing.Test.Tools.Newses.Factories
{
    public class UpdateNewsDtoFactory
    {
        public static UpdateNewsDto Create()
        {
            return new UpdateNewsDto()
            {
                Title = "Update-dummy-title ",
                Weight = 5,

            };
        }
    }
}
