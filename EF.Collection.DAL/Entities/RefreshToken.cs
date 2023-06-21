using System.Text.Json.Serialization;

namespace EFCollections.DAL.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserSecret { get; set; }
        public DateTime? ExpirationDate { get; set; }
        [JsonIgnore] public User? User { get; set; }
    }
}
