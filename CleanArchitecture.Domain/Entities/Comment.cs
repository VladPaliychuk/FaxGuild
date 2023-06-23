using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public string Data { get; set; } = null!;
        public int Likes { get; set; }
        public int PostId { get; set; }

        public ICollection<Reply>? Replies { get; set; }
    }
}
