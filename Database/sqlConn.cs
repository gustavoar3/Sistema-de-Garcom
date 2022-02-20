// Essa classe descobre o hostname do usuário e cria a cadeia de conexão para o SQL Server

namespace Database
{
    public class SqlConn
    {
        public static string GetSqlConn()
        {
            string hostname = System.Net.Dns.GetHostEntry("").HostName;

            return "Integrated Security=SSPI;Persist Security Info=False;Data Source=" + hostname + "\\SQLEXPRESS";
        }
    }
}
