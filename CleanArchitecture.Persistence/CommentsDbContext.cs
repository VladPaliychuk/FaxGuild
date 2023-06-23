using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence
{
    public class CommentsDbContext : DbContext
    {
        public CommentsDbContext(DbContextOptions options ) : base(options) { }

        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Reply> Replies => Set<Reply>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ReplyConfiguration());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}