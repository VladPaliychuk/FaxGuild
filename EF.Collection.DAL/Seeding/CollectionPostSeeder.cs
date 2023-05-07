using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class CollectionPostSeeder : ISeeder<CollectionPost>
    {
        private static readonly List<CollectionPost> collectionposts = new()
        {
            new CollectionPost
            {
                CollectionID = 1,
                PostID = 1
            }
        };

        public void Seed(EntityTypeBuilder<CollectionPost> builder) => builder.HasData(collectionposts);
    }
}
