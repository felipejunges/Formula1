using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class EquipeConfig : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasMany(c => c.Contratos)
                .WithOne(c => c.Equipe)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Resultados)
                .WithOne(c => c.Equipe)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}