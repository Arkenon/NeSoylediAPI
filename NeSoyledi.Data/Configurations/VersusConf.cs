using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Configurations
{
    class VersusConf : IEntityTypeConfiguration<Versus>
    {
        public void Configure(EntityTypeBuilder<Versus> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
               .HasOne(m => m.Category);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Versus");
        }
    }
}
