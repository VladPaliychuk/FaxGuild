using EFCollections.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(u => u.Id);

            builder.Property(u => u.Name);

            //builder.HasData(DataSeeder.Users);
            //new UserSeeder().Seed(builder);
        }
    }
}
