using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class ResultadoConfig : IEntityTypeConfiguration<Resultado>
    {
        public void Configure(EntityTypeBuilder<Resultado> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Corrida)
                .WithMany(c => c.Resultados)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Equipe)
                .WithMany(c => c.Resultados)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Piloto)
                .WithMany(c => c.Resultados)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}