using CleanArchitecture.Domain.Common;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public string Data { get; set; } = null!;
        public int Likes { get; set; }
        public int PostId { get; set; }

        [JsonIgnore]
        public ICollection<Reply>? Replies { get; set; }
    }
}
