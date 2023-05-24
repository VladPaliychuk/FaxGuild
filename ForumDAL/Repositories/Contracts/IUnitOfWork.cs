namespace ForumDAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository _postRepository { get; }
        ITagRepository _tagRepository { get; }
        IPostTagRepository _postTagRepository { get; }
        void Commit();
        void Dispose();
    }
}
