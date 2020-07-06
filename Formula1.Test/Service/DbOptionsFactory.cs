using Formula1.Infra.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Formula1.Test.Service
{
    public class DbOptionsFactory
    {
        static DbOptionsFactory()
        {
            Configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            DbContextOptions = new DbContextOptionsBuilder<F1Db>()
                    .UseSqlite(Configuration.GetConnectionString("SqliteConnection"))
                    .Options;

            DbMemoryContextOptions = new DbContextOptionsBuilder<F1Db>()
                .UseInMemoryDatabase(databaseName: "Teste")
                .Options;
        }

        public static DbContextOptions<F1Db> DbContextOptions { get; }
        public static DbContextOptions<F1Db> DbMemoryContextOptions { get; }
        public static IConfiguration Configuration { get; }
    }
}