namespace Forum.DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository _postRepository { get; }
        ITagRepository _tagRepository { get; }
        void Commit();
        void Dispose();
    }
}
