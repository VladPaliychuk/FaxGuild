using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class CollectionPostConfiguration : IEntityTypeConfiguration<CollectionPost>
    {
        public void Configure(EntityTypeBuilder<CollectionPost> builder)
        {
            builder.HasKey(cp => new { cp.CollectionId, cp.PostId });

            builder.HasOne(cp => cp.Post).WithMany(p => p.CollectionPosts).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.ClientCascade) ;
            builder.HasOne(cp => cp.Collection).WithMany(c => c.CollectionPosts).HasForeignKey(c => c.CollectionId).OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasData(DataSeeder.CollectionPosts);
            //new CollectionPostSeeder().Seed(builder);
        }
    }
}
