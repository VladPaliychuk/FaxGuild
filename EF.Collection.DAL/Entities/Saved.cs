using System.Text.Json.Serialization;

namespace EFCollections.DAL.Entities
{
    //[Keyless]
    public class Saved
    {
        //public Guid Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        [JsonIgnore] public User? User { get; set; }
        [JsonIgnore] public Post? Post { get; set; }
    }
}
