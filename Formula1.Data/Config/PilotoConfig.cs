using Formula1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1.Data.Config
{
    public class PilotoConfig : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            
        }
    }
}