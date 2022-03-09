using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Infra.Database
{
    public class F1Db : DbContext
    {
        public F1Db(DbContextOptions<F1Db> options) : base(options) { }

        public DbSet<Contrato> Contratos => Set<Contrato>();

        public DbSet<Corrida> Corridas => Set<Corrida>();

        public DbSet<Equipe> Equipes => Set<Equipe>();

        public DbSet<EquipeTemporada> EquipesTemporada => Set<EquipeTemporada>();

        public DbSet<Piloto> Pilotos => Set<Piloto>();

        public DbSet<PilotoTemporada> PilotosTemporada => Set<PilotoTemporada>();

        public DbSet<Punicao> Punicoes => Set<Punicao>();

        public DbSet<Resultado> Resultados => Set<Resultado>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

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