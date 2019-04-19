using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class CorridaConfig : IEntityTypeConfiguration<Corrida>
    {
        public void Configure(EntityTypeBuilder<Corrida> builder)
        {
            builder.HasMany(c => c.Resultados)
                .WithOne(c => c.Corrida)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}