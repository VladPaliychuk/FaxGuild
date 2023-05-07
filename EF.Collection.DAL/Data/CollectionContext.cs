using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Configuration;

namespace EFCollections.DAL.Data
{ 
    public class CollectionContext : DbContext 
    {
        public DbSet<Collection> Collection { get; set; }
        public DbSet<CollectionPost> CollectionPost { get; set; }
        public DbSet<Saved> Saved { get; set; }
        public DbSet<Storage> Storage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionPostConfiguration());
            modelBuilder.ApplyConfiguration(new SavedConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=FaxGuild2;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
            }
        }

        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {
        }
    }
}
