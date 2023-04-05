using System.Data.SqlClient;

namespace Forum.DAL.Repositories
{
    public class Connection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FaxGuild;Integrated Security=True");
        }
    }
}
