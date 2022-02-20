using System.Data;
using System.Data.SqlClient;


namespace Database
{
    public class Menu
    {
        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(SqlConn.GetSqlConn()))
            {
                // Cria as tabelas e as preenchem
                string queryDoc = "CREATE TABLE menuSB( " +
                                "   Id int IDENTITY(1,1) NOT NULL, " +
                                "   Nome varchar(50) NULL, " +
                                "   Descricao text NULL, " +
                                "   Tipo bit NULL, " +
                            ") " +

                            "CREATE TABLE pedidoSB( " +
                            "   Id int IDENTITY(1, 1) NOT NULL, " +
                            "   NomeCliente varchar(50) NOT NULL, " +
                            "   Mesa int NOT NULL, " +
                            "   Prato varchar(50) NULL, " +
                            "   QtdPrato int NULL, " +
                            "   Bebida varchar(50) NULL, " +
                            "   QtdBebida int NULL, " +
                            "   PratoR bit NULL, " +
                            "   BebidaR bit NULL, " +
                            "   Entregue bit NULL, " +
                            ") " +

                            "SET IDENTITY_INSERT menuSB ON " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(1, 'Tambaqui Assado', 'Prato tipico da Amazonia, consiste do peixe assado na brasa seguido de acompanhamentos.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(2, 'Bailao de Dois', 'Prato cearense. Feito de arroz, feijao, carne seca e queijo coalho.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(3, 'Moqueca', 'Comida capixaba. Prato feito por peixe cozinho e frutos do mar.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(4, 'Frango com Quiabo', 'Prato mineiro. Consiste em frango com quiabo e angu.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(5, 'Tropeiro', 'Prato tipico de Minas Gerais. Feito de feijao, farinha, torresmo, linguiça e ovos.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(6, 'Feijoada', 'Comida carioca. Consiste em feijao preto, e carnes salgadas.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(7, 'Virado a paulista', 'Prato paulista. Feito de feijao cozido, com linguica, torresmo, ovo de acompanhamentos.', 0); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(8, 'Suco de Frutas', 'Suco de laranja, abacaxi ou limonada.', 1); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(9, 'Refrigerantes', 'Lata, garrafa, diversos sabores.', 1); " +

                            "INSERT INTO menuSB(id, nome, descricao, tipo) " +
                            "   VALUES(10, 'Bebidas Alcolicas', 'Cervejas, Vinhos, Rum, Vodka e Whiske.', 1); " +

                            "SET IDENTITY_INSERT menuSB OFF ";

                // Conecta ao SQL Server e executa os comandos acima, caso ja tiver sido executado, apenas continua
                try
                {
                    SqlCommand myCommand = new SqlCommand(queryDoc, connection);
                    myCommand.Connection.Open();
                    myCommand.ExecuteNonQuery();
                }
                catch { }

                // Lê a tabela menuSB criada
                string queryString = "select * from menuSB";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
