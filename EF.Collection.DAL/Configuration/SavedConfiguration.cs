using EFCollections.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Configuration
{
    public class SavedConfiguration : IEntityTypeConfiguration<Saved>
    {
        public void Configure(EntityTypeBuilder<Saved> builder)
        {
            builder.Property(saved => saved.UserID)
                   .IsRequired();

            builder.Property(saved => saved.PostID)
                   .IsRequired();

            new SavedSeeder().Seed(builder);
        }
    }
}
