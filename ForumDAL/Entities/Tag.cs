using System.ComponentModel.DataAnnotations;

namespace ForumDAL.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
