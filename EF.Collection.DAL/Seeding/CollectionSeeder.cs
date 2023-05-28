using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class CollectionSeeder : ISeeder<Collection>
    {
        private static readonly List<Collection> c = new()
        {
            new Collection
            {
                Id=1,
                AuthorId = 1,
            },
            new Collection
            {
                Id=2,
                AuthorId = 2,
            },
            new Collection
            {
                Id=3,
                AuthorId = 3,
            },
            new Collection
            {
                Id=4,
                AuthorId = 4,
            },
            new Collection
            {
                Id=5,
                AuthorId = 5,
            }
        };
        public void Seed(EntityTypeBuilder<Collection> builder)
        {
            builder.HasData(c);
        }
    }
}
