namespace EFCollections.BLL.DTO.Responses
{
    public class JwtResponse
    {
        public string UserName { get; set; } = null!;
        public string Token { get; set;} = null!;
        public string RefreshToken { get; set; } = null!;
        public string UserId { get; internal set; }
    }
}
