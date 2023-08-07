using MySqlConnector;
using System.Configuration;

namespace TodoNeogrid.Infra.Context
{
    public class TodoContext
    {
        private readonly MySqlConnection _connection;

        public MySqlConnection CriarConexao()
        {
            if (_connection != null)
                return _connection;

            var conexaoOper = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conexaoOper.Open();

            return conexaoOper;
        }
    }
}