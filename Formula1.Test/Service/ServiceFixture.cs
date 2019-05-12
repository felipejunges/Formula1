using Formula1.Infra.Database.SqlServer;
using System;

namespace Formula1.Test.Service
{
    public class ServiceFixture : IDisposable
    {
        public readonly F1Db Db;

        public ServiceFixture()
        {
            Db = new F1Db(DbOptionsFactory.DbMemoryContextOptions);
            Db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}