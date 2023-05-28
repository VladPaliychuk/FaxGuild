using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class StorageSeeder : ISeeder<Storage>
    {
        private static readonly List<Storage> s = new()
        {
            new Storage
            {
                UserId = 1,
                PostId = 1
            },
            new Storage
            {
                UserId = 2,
                PostId = 1
            },
            new Storage
            {
                UserId = 3,
                PostId = 1
            },
            new Storage
            {
                UserId = 4,
                PostId = 1
            },
            new Storage
            {
                UserId = 5,
                PostId = 1
            }
        };
        public void Seed(EntityTypeBuilder<Storage> builder)
        {
            builder.HasData(s);
        }
    }
}
