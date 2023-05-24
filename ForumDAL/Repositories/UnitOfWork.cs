using ForumDAL.Repositories.Contracts;
using System.Data;

namespace ForumDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IPostRepository _postRepository { get; }
        public ITagRepository _tagRepository { get; }
        public IPostTagRepository _postTagRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            IPostRepository postRepository,
            ITagRepository tagRepository,
            IPostTagRepository postTagTagRepository,
            IDbTransaction dbTransaction)
        {
            _postRepository= postRepository;
            _tagRepository= tagRepository;
            _postTagRepository= postTagTagRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}