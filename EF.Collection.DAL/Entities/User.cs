using System.Text.Json.Serialization;

namespace EFCollections.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore] public ICollection<Storage>? Storages { get; set; }
        [JsonIgnore] public ICollection<Saved>? Saveds { get; set; }
        [JsonIgnore] public ICollection<Collection>? Collections { get; set; }
        [JsonIgnore] public ICollection<Post>? Posts { get; set; }
    }
}
    