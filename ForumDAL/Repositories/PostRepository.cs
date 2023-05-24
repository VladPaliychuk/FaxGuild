using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ForumDAL.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Forum.Post")
        {
        }

        public async Task<IEnumerable<Tag>>GetAllTagsByPostIdAsync(int id)
        {
            return await _sqlConnection.QueryAsync<Tag>($"SELECT Tag.Name " +
                $"FROM Post AS P " +
                $"JOIN PostTag AS PT ON P.Id = PT.PostId " +
                $"JOIN Tag AS T ON PT.TagId = T.Id " +
                $"WHERE P.Id = @Id",
                param: new { Id = id },
                transaction: _dbTransaction);
        }
        public new async Task DeleteAsync(int id)
        {
            await _sqlConnection.ExecuteAsync($"DELETE FROM Forum.PostTag where PostId=@Id " +
                $"DELETE FROM Forum.Post WHERE Id=@Id",
               param: new { Id = id },
               transaction: _dbTransaction);
        }
    }
}
