using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.DTO.Requests
{
    public class PostRequest
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        public string Picture { get; set; } = null!;
        public DateTime CreateTime { get; set; }
    }
}
