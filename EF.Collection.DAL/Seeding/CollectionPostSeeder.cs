using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class CollectionPostSeeder : ISeeder<CollectionPost>
    {
        private static readonly List<CollectionPost> cp = new()
        {
            new CollectionPost
            {
                CollectionId = 1,
                PostId = 1
            },
            new CollectionPost
            {
                CollectionId = 2,
                PostId = 2
            },
            new CollectionPost
            {
                CollectionId = 3,
                PostId = 3
            },
            new CollectionPost
            {
                CollectionId = 4,
                PostId = 4
            },
            new CollectionPost
            {
                CollectionId = 5,
                PostId = 5
            }
        };
        public void Seed(EntityTypeBuilder<CollectionPost> builder)
        {
            builder.HasData(cp);
        }
    }
}
