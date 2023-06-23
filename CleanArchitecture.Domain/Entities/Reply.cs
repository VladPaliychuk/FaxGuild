using CleanArchitecture.Domain.Common;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Entities
{
    public class Reply : BaseAuditableEntity
    {
        public string Data { get; set; } = null!;
        public int CommentId { get; set; }

        [JsonIgnore]
        public Comment? Comment { get; set; }
    }
}
