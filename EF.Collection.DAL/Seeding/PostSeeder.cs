using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class PostSeeder : ISeeder<Post>
    {
        private static readonly List<Post> p = new()
        {
            new Post
            {Id = 1,
                Likes = 5,
                UserId = 1,
                Picture = "Picture1",
                CreateTime = DateTime.Now
            },
            new Post
            {Id = 2,    
                Likes = 50,
                UserId = 2,
                Picture = "Picture2",
                CreateTime = DateTime.Now
            },
            new Post
            {Id = 3,
                Likes = 1000,
                UserId = 3,
                Picture = "Picture3",
                CreateTime = DateTime.Now
            },
            new Post
            {Id=4,
                Likes = 1,
                UserId = 4,
                Picture = "Picture4",
                CreateTime = DateTime.Now
            },
            new Post
            {Id = 5,
                Likes = 354,
                UserId = 1,
                Picture = "Picture5",
                CreateTime = DateTime.Now
            }
        };
        public void Seed(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(p);
        }
    }
}
