using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Infra.SqlServer
{
    public class F1Db : DbContext
    {
        public DbSet<Corrida> Corridas { get; set; }
    }
}