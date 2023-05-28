using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class SavedSeeder : ISeeder<Saved>
    {
        private static readonly List<Saved> s = new()
        {
            new Saved
            {
                UserId = 1,
                PostId=1
            },
            new Saved
            {
                UserId = 2,
                PostId=2
            },
            new Saved
            {
                UserId = 3,
                PostId=1
            },
            new Saved
            {
                UserId=4,
                PostId=5
            },
            new Saved
            {
                UserId = 5,
                PostId=1
            }
        };
        public void Seed(EntityTypeBuilder<Saved> builder)
        {
            builder.HasData(s);
        }
    }
}
