using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class CorridaConfig : IEntityTypeConfiguration<Corrida>
    {
        public void Configure(EntityTypeBuilder<Corrida> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasIndex(i => i.Temporada);
        }
    }
}