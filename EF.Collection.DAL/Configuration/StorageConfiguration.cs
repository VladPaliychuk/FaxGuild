using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(cp => new { cp.UserId, cp.PostId });

            builder.HasOne(cp => cp.Post).WithMany(p => p.Storages).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(cp => cp.User).WithMany(c => c.Storages).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasData(DataSeeder.Storages);
            //new StorageSeeder().Seed(builder);
        }
    }
}
