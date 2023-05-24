using System.Data.SqlClient;

namespace ForumDAL.Repositories
{
    public class Connection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Server=.\\SQLEXPRESS;Initial Catalog=FaxGuild;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}
