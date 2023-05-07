using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class SavedSeeder : ISeeder<Saved>
    {
        private static readonly List<Saved> saved = new()
        {
            new Saved
            {
                UserID = 1,
                PostID = 1
            }
        };

        public void Seed(EntityTypeBuilder<Saved> builder) => builder.HasData(saved);
    }
}
