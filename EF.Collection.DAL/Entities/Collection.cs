using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCollections.DAL.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        [JsonIgnore] public User? User { get; set; }
        [JsonIgnore] public ICollection<CollectionPost>? CollectionPosts { get; set; }
    }
}
