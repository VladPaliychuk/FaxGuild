using Bogus;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using System.Reflection.Metadata;

namespace EFCollections.DAL.Seeding
{
/*    public static class DataSeeder
    {
        static DataSeeder()
        {
            if (Users is null && Storages is null && Saveds is null && Posts is null &&
                CollectionPosts is null && Collections is null)
            {
                Initialize();
            }
        }

        public static List<User> Users { get; set; } = null!;
        public static List<Storage> Storages { get; set; } = null!;
        public static List<Saved> Saveds { get; set; } = null!;
        public static List<Post> Posts { get; set; } = null!;
        public static List<CollectionPost> CollectionPosts { get; set; } = null!;
        public static List<Collection> Collections { get; set; } = null!;

        private static void Initialize()
        {
            Users = GetUserGen().Generate(5);
            Posts = GetPostGen().Generate(5);
            Collections = GetCollectionGen().Generate(5);
            CollectionPosts = GetCollectionPostsGen().Generate(5);
            Saveds = GetSavedGen().Generate(5);
            Storages = GetStorageGen().Generate(5);
        }

        private static Faker<User> GetUserGen()
        {
            return new Faker<User>()
                .RuleFor(c => c.Id, f => f.Random.Number(1, 100))
                .RuleFor(u => u.Name, f => f.Name.Random.Words());
        }
        private static Faker<Post> GetPostGen()
        {
            return new Faker<Post>()
                .RuleFor(c => c.Id, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Likes, f => f.Random.Int(0, 100))
                .RuleFor(p => p.UserId, f => f.PickRandom(Users).Id)
                .RuleFor(p => p.Picture, f => f.Lorem.Word())
                .RuleFor(p => p.CreateTime, f => f.Date.Past(15));
        }
        private static Faker<Storage> GetStorageGen()
        {
            return new Faker<Storage>()
                .RuleFor(st => st.UserId, f => f.PickRandom(Users).Id)
                .RuleFor(st => st.PostId, f => f.PickRandom(Posts).Id);
        }
        private static Faker<Saved> GetSavedGen()
        {
            return new Faker<Saved>()
                .RuleFor(s => s.UserId, f => f.PickRandom(Users).Id)
                .RuleFor(s => s.PostId, f => f.PickRandom(Posts).Id);
        }
        private static Faker<Collection> GetCollectionGen()
        {
            return new Faker<Collection>()
                .RuleFor(c => c.Id, f => f.Random.Number(1,100))
                .RuleFor(c => c.AuthorId, f => f.PickRandom(Users).Id);
        }
        private static Faker<CollectionPost> GetCollectionPostsGen()
        {
            return new Faker<CollectionPost>()
                .RuleFor(cp => cp.CollectionId, f => f.PickRandom(Collections).Id)
                .RuleFor(cp => cp.PostId, f => f.PickRandom(Posts).Id);
        }
        *//*public static List<User> Users { get; set; } = new();
        public static List<Storage> Storages { get; set; } = new();
        public static List<Saved> Saveds { get; set; } = new();
        public static List<Post> Posts { get; set; } = new();
        public static List<CollectionPost> CollectionPosts { get; set; } = new();
        public static List<Collection> Collections { get; set; } = new();
        public static void SeedingInit()
        {
            Posts = new Faker<Post>()
                .RuleFor(p => p.Likes, f => f.Random.Int(0, 100))
                .RuleFor(p => p.UserId, f => f.PickRandom(Users).Id)
                .RuleFor(p => p.Picture, f => f.Lorem.Word())
                .RuleFor(p => p.CreateTime, f => f.Date.Past(15));

            Users = new Faker<User>()
                .RuleFor(u => u.Name, f => f.Name.Random.Words())
                .RuleFor(u => u.StorageId, f => f.PickRandom(Storages).Id)
                .RuleFor(u => u.SavedId, f => f.PickRandom(Saveds).Id);

            Storages = new Faker<Storage>()і
                .RuleFor(st => st.PostId, f => f.PickRandom(Posts).Id);

            Saveds = new Faker<Saved>()
                .RuleFor(s => s.PostId, f => f.PickRandom(Posts).Id);

            Collections = new Faker<Collection>()
                .RuleFor(c => c.AuthorId, f => f.PickRandom(Users).Id);

            CollectionPosts = new Faker<CollectionPost>()
                .RuleFor(cp => cp.CollectionId, f => f.PickRandom(Collections).Id)
                .RuleFor(cp => cp.PostId, f => f.PickRandom(Posts).Id);
        }*//*
    }*/
}
