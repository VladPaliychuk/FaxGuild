using Microsoft.AspNetCore.Identity;

namespace EFCollections.BLL.DTO.Responses
{
    public class UserResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
