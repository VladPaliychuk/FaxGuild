using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Entities
{
    //[Keyless]
    public class CollectionPost
    {
        public int CollectionId { get; set; }
        public int PostId { get; set; }

        public Collection? Collection { get; set; }
        public Post? Post { get; set; }
    }
}
