using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ISS.Application.LinqToDb
{
    public class DbSettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();
        protected string Name { get; }
        protected string ProviderName { get; }
        protected string ConnectionString { get; }

        public DbSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "SqlServer",
                        ProviderName = "SqlServer",
                        ConnectionString = ConnectionString
                    };
            }
        }
    }
}