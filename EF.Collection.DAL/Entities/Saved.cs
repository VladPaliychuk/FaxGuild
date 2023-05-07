using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Entities
{
    [Keyless]
    public class Saved
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
    }
}
