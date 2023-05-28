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
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<User> u = new()
        {
            new User
            {
                Id=1,
                Name = "User1",
            },
            new User
            {
                Id=2,
                Name = "User2",
            },
            new User
            {Id = 3,
                Name = "User3",
            },
            new User
            {Id = 4,
                Name = "User4",
            },
            new User
            {Id = 5,    
                Name = "User5",
            }
        };
            public void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(u);
        }
    }
}
