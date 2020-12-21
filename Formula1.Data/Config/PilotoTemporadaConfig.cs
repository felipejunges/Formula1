using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class PilotoTemporadaConfig : IEntityTypeConfiguration<PilotoTemporada>
    {
        public void Configure(EntityTypeBuilder<PilotoTemporada> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Piloto)
                .WithMany(c => c.Temporadas)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}