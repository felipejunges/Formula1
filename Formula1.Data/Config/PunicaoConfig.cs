﻿using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class PunicaoConfig : IEntityTypeConfiguration<Punicao>
    {
        public void Configure(EntityTypeBuilder<Punicao> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.HasOne(h => h.Equipe)
                .WithMany(c => c.Punicoes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Piloto)
                .WithMany(c => c.Punicoes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Corrida)
                .WithMany(c => c.Punicoes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}