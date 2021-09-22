using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Configurations
{
    class ReactionConf : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Reactions");
        }
    }
}
