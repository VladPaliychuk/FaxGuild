using EFCollections.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Configuration
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.Property(storages => storages.UserID)
                   .IsRequired();

            builder.Property(storages => storages.PostID)
                   .IsRequired();

            new StorageSeeder().Seed(builder);
        }
    }
}
