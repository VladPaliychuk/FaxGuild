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
            builder.HasKey(cp => new { cp.PostId, cp.UserId });

            builder.HasOne(cp => cp.Post).WithMany(p => p.Saveds).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(cp => cp.User).WithMany(c => c.Saveds).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasData(DataSeeder.Saveds);
            //new SavedSeeder().Seed(builder);
        }
    }
}
