using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Configurations
{
    class NewsConf : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("News");
        }
    }
}
