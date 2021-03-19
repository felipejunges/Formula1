using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class ContratoConfig : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Equipe)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.EquipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Piloto)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.PilotoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => i.Temporada);
        }
    }
}