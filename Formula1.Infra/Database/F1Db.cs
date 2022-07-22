using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Formula1.Infra.Database
{
    public class F1Db : DbContext
    {
        private readonly IConfiguration _configuration;

        public F1Db(DbContextOptions<F1Db> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Contrato> Contratos => Set<Contrato>();

        public DbSet<Corrida> Corridas => Set<Corrida>();

        public DbSet<Equipe> Equipes => Set<Equipe>();

        public DbSet<EquipeTemporada> EquipesTemporada => Set<EquipeTemporada>();

        public DbSet<Piloto> Pilotos => Set<Piloto>();

        public DbSet<PilotoTemporada> PilotosTemporada => Set<PilotoTemporada>();

        public DbSet<Punicao> Punicoes => Set<Punicao>();

        public DbSet<Resultado> Resultados => Set<Resultado>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnection"), b => b.MigrationsAssembly("Formula1.Infra"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Data.Config.ContratoConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.CorridaConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.EquipeConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.EquipeTemporadaConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.PilotoConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.PilotoTemporadaConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.PunicaoConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.ResultadoConfig());
            modelBuilder.ApplyConfiguration(new Data.Config.UsuarioConfig());
        }
    }
}