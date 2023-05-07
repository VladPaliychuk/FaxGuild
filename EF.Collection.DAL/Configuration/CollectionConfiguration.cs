using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.Property(collections => collections.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(collections => collections.AuthorID)
                   .HasMaxLength(50)
                   .IsRequired(); 

            new CollectionSeeder().Seed(builder);
        }
    }
}
