using System.Data.SqlClient;
using System.Data;
using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;

namespace ForumDAL.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Forum.Tag")
        {

        }
    }
}
