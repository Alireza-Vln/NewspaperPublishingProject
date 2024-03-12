using NewspaperPublishing.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewspaperPublishing.Test.Tools.Infrastructure.DatabaseConfig.Integration
{
    [Collection(nameof(ConfigurationFixture))]
    public class EFDataContextDatabaseFixture : DatabaseFixture
    {
        protected static EFDataContext CreateDataContext()
        {
            var connectionString =
                new ConfigurationFixture().Value.DbConnectionString;

            return new EFDataContext(connectionString);
        }
    }
}
