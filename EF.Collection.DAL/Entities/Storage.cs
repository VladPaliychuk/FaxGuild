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
    public class Storage
    {
        //public Guid Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        [JsonIgnore] public User? User { get; set; }
        [JsonIgnore] public Post? Post { get; set; }
    }
}
