using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.DataContext
{
    public partial class EDbContext : DbContext
    {
        public EDbContext()
        {
            
        }

        public EDbContext(DbContextOptions<EDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=shopdb");
            }
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");
                modelBuilder.HasPostgresExtension("uuid-ossp");
                OnModelCreatingPartial(modelBuilder);
            }
            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}