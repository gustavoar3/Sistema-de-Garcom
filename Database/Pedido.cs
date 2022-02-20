using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Pedido
    {
        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(SqlConn.GetSqlConn()))
            {
                // Lê a tabela pedidoSB
                string queryString = "select * from pedidoSB";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string nomeCliente, int mesa, string prato, int qtdPrato, string bebida, int qtdBebida, bool pratoR, bool bebidaR, bool entregue)
        {
            using (SqlConnection connection = new SqlConnection(SqlConn.GetSqlConn()))
            {
                // Utiliza o comando insert para preencher uma nova linha na tabela seguindo a ordem de id, porém, caso seja recebido um id, utiliza update para alterar uma linha já existente                
                string queryString = "insert into pedidoSB(nomeCliente, mesa, prato, qtdprato, bebida, qtdbebida, pratoR, bebidaR, entregue) values('" + nomeCliente + "', '" + mesa + "', '" + prato + "', '" + qtdPrato + "', '" + bebida + "', '" + qtdBebida + "', '" + pratoR + "', '" + bebidaR + "', '" + entregue + "')";
                if (id != 0)
                {
                    queryString = "update pedidoSB set nomeCliente='" + nomeCliente + "', mesa='" + mesa + "', prato='" + prato + "', qtdprato='" + qtdPrato + "', bebida='" + bebida + "', qtdbebida='" + qtdBebida + "', pratoR='" + pratoR + "', bebidaR='" + bebidaR + "', entregue='" + entregue + "' where id=" + id;
                }

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(SqlConn.GetSqlConn()))
            {
                // Lê as colunas que possuem o id solucitado, que no caso, será sempre apenas uma
                string queryString = "select * from pedidoSB where id=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(SqlConn.GetSqlConn()))
            {
                // Utiliza o comando delete para retirar a coluna de id especificado da tabela
                string queryString = "delete from pedidoSB where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
