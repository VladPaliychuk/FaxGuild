using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollection.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.Property(project => project.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(project => project.AuthorID)
                   .HasMaxLength(50)
                   .IsRequired(); 

            new CollectionSeeder().Seed(builder);
        }
    }
}
