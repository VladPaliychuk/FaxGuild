namespace EFCollections.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public ICollection<Storage>? Storages { get; set; }
        public ICollection<Saved>? Saveds { get; set; }
        public ICollection<Collection>? Collections { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
    