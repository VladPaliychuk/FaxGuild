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
            builder.Property(collectionposts => collectionposts.CollectionID)
                   .IsRequired();

            builder.Property(collectionposts => collectionposts.PostID)
                   .IsRequired();

            new CollectionPostSeeder().Seed(builder);
        }
    }
}
