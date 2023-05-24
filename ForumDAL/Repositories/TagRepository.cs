using System.Data.SqlClient;
using System.Data;
using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using Dapper;

namespace ForumDAL.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Forum.Tag")
        {

        }
        public new async Task DeleteAsync(int id)
        {
            await _sqlConnection.ExecuteAsync($"DELETE FROM Forum.PostTag where TagId=@Id " +
                $"DELETE FROM Forum.Tag WHERE Id=@Id",
               param: new { Id = id },
               transaction: _dbTransaction);
        }
    }
}
