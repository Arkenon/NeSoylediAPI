using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSoyledi.Data.Configurations
{
    class ProfilesConf : IEntityTypeConfiguration<Profiles>
    {
        public void Configure(EntityTypeBuilder<Profiles> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
               .HasMany(m => m.Discourses);
            builder
                .Property(m => m.Id).ValueGeneratedOnAdd();
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .ToTable("Profiles");
        }
    }
}
