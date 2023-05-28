namespace EFCollections.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        public string Picture { get; set; } = null!;
        public DateTime CreateTime { get; set; }

        public User? User { get; set; }
        //public ICollection<User>? Users { get; set; }
        public ICollection<Storage>? Storages { get; set; }
        public ICollection<Saved>? Saveds { get; set; }
        public ICollection<CollectionPost>? CollectionPosts { get; set; }
    }
}
