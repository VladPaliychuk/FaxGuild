using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace ForumDAL.Repositories
{
    public class PostTagRepository : GenericRepository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Forum.PostTag")
        {

        }

    }
}
