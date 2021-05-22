using Microsoft.EntityFrameworkCore;
using NeSoyledi.Data.Configurations;
using NeSoyledi.Entities;

namespace NeSoyledi.Data
{
    public class NeSoylediDbContext : DbContext
    {
        public NeSoylediDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Option> Options { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Discourse> Discourses { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Versus> Versus { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CategoryConf());
            builder
                .ApplyConfiguration(new DiscourseConf());
            builder
               .ApplyConfiguration(new ProfilesConf());
            builder
               .ApplyConfiguration(new UserConf());
            builder
               .ApplyConfiguration(new VersusConf());
        }

    }
}
