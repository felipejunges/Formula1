using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class EquipeTemporadaConfig : IEntityTypeConfiguration<EquipeTemporada>
    {
        public void Configure(EntityTypeBuilder<EquipeTemporada> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Equipe)
                .WithMany(c => c.Temporadas)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}