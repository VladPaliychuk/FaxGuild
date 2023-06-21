using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace EFCollections.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;

        [JsonIgnore] public ICollection<Storage>? Storages { get; set; }
        [JsonIgnore] public ICollection<Saved>? Saveds { get; set; }
        [JsonIgnore] public ICollection<Collection>? Collections { get; set; }
        [JsonIgnore] public ICollection<Post>? Posts { get; set; }
        [JsonIgnore] public RefreshToken? RefreshToken { get; set; }
    }
}
    