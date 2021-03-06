using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Formula1.Infra.Database
{
    public class F1Db : DbContext
    {
        public F1Db(DbContextOptions<F1Db> options) : base(options) { }

        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<Corrida> Corridas { get; set; }

        public DbSet<Equipe> Equipes { get; set; }

        public DbSet<EquipeTemporada> EquipesTemporada { get; set; }

        public DbSet<Piloto> Pilotos { get; set; }

        public DbSet<PilotoTemporada> PilotosTemporada { get; set; }

        public DbSet<Punicao> Punicoes { get; set; }

        public DbSet<Resultado> Resultados { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

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