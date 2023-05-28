using EFCollections.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Likes);

            builder.Property(p => p.Picture);

            builder.Property(p => p.CreateTime);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
            
            //builder.HasData(DataSeeder.Posts);
            //new PostSeeder().Seed(builder);
        }
    }
}
