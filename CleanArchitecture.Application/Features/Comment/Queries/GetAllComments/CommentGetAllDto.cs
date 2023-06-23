using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Comment.Queries.GetAllComments
{
    public class CommentGetAllDto
    {
        public int Id { get; set; }
        public string Data { get; set; } = null!;
        public int Likes { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
