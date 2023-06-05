using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EFCollections.DAL.Data
{ 
    public class CollectionContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public CollectionContext(DbContextOptions options) : base(options) { }

        //public DbSet<User> Users => Set<User>();
        //public DbSet<Post> Posts => Set<Post>();
        //public DbSet<Collection> Collections => Set<Collection>();
        //public DbSet<CollectionPost> CollectionPosts => Set<CollectionPost>();
        //public DbSet<Saved> Saveds => Set<Saved>();
        //public DbSet<Storage> Storages => Set<Storage>();
        //public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionPost> CollectionPosts { get; set; }
        public DbSet<Saved> Saveds { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionPostConfiguration());
            modelBuilder.ApplyConfiguration(new SavedConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=FaxGuild2;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
            }
        }*/
    }
}
