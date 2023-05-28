using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCollections.DAL.Entities
{
    //[Keyless]
    public class CollectionPost
    {
        public int CollectionId { get; set; }
        public int PostId { get; set; }

        [JsonIgnore] public Collection? Collection { get; set; }
        [JsonIgnore] public Post? Post { get; set; }
    }
}
