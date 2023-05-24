using System.ComponentModel.DataAnnotations;

namespace ForumDAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int? Likes { get; set; }
        public int UserId { get; set; }
        public string? Picture { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
