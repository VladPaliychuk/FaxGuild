namespace EFCollections.BLL.DTO.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        public string Picture { get; set; } = null!;
        public DateTime CreateTime { get; set; }
    }
}
