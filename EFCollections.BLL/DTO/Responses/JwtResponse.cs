namespace EFCollections.BLL.DTO.Responses
{
    public class JwtResponse
    {
        public string UserName { get; set; } = null!;
        public int Id { get; set; }

        public string? Token { get; set;}
        //public string RefreshToken { get; set; } = null!;
    }
}
