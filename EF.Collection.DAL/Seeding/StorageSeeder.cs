using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Seeding
{
    public class StorageSeeder : ISeeder<Storage>
    {
        private static readonly List<Storage> storages = new()
        {
            new Storage
            {
                UserID = 1,
                PostID = 1
            }
        };

        public void Seed(EntityTypeBuilder<Storage> builder) => builder.HasData(storages);
    }
}
