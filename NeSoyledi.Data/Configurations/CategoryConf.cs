using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Configurations
{
    public class CategoryConf : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
               .HasMany(m => m.Discourses);
            builder
              .HasMany(m => m.Versus);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Categories");
        }
    }
}
