using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Configurations
{
    class DiscourseConf:IEntityTypeConfiguration<Discourse>
    {
        public void Configure(EntityTypeBuilder<Discourse> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
               .HasOne(m => m.Category);
            builder
               .HasOne(m => m.Profile);
            builder
               .HasOne(m => m.Organization);
            builder
               .HasOne(m => m.User);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Discourses");
        }
    }
}
