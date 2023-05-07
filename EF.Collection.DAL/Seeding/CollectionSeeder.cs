using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;

namespace EFCollections.DAL.Seeding
{
    public class CollectionSeeder : ISeeder<Collection>
    {
        private static readonly List<Collection> collections = new()
        {
            new Collection
            {
                Id = 1,
                AuthorID = 1
            }
        };

        public void Seed(EntityTypeBuilder<Collection> builder) => builder.HasData(collections);
    }
}
