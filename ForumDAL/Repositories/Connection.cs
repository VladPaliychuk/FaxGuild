using System.Data.SqlClient;

namespace ForumDAL.Repositories
{
    public class Connection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FaxGuild;Integrated Security=True");
        }
    }
}
