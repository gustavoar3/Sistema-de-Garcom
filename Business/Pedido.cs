using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int Mesa { get; set; }
        public string Prato { get; set; }
        public int QtdPrato { get; set; }
        public string Bebida { get; set; }
        public int QtdBebida { get; set; }
        public bool PratoR { get; set; }
        public bool BebidaR { get; set; }
        public bool Entregue { get; set; }

        public List<Pedido> Lista()
        {
            // Inicializa a lista Pedido que contém os dados da tabela pedidoSB
            var lista = new List<Pedido>();
            var pedidoDb = new Database.Pedido();
            foreach (DataRow row in pedidoDb.Lista().Rows)
            {
                var pedidos = new Pedido();

                pedidos.Id = Convert.ToInt32(row["id"]);
                pedidos.NomeCliente = row["nomecliente"].ToString();
                pedidos.Mesa = Convert.ToInt32(row["mesa"]);
                pedidos.Prato = row["prato"].ToString();
                pedidos.QtdPrato = Convert.ToInt32(row["qtdprato"]);
                pedidos.Bebida = row["bebida"].ToString();
                pedidos.QtdBebida = Convert.ToInt32(row["qtdbebida"]);
                pedidos.PratoR = Convert.ToBoolean(row["PratoR"]);
                pedidos.BebidaR = Convert.ToBoolean(row["BebidaR"]);
                pedidos.Entregue = Convert.ToBoolean(row["entregue"]);

                lista.Add(pedidos);
            }

            return lista;
        }

        public static Pedido BuscaPorId(int id)
        {
            // Através do id recebido, executa a função na database e retorna a struct com todos os dados desse id
            var pedido = new Pedido();
            var pedidoDb = new Database.Pedido();
            foreach (DataRow row in pedidoDb.BuscaPorId(id).Rows)
            {
                pedido.Id = id;
                pedido.NomeCliente = row["nomecliente"].ToString();
                pedido.Mesa = Convert.ToInt32(row["mesa"]);
                pedido.Prato = row["prato"].ToString();
                pedido.QtdPrato = Convert.ToInt32(row["qtdprato"]);
                pedido.Bebida = row["bebida"].ToString();
                pedido.QtdBebida = Convert.ToInt32(row["qtdbebida"]);
                pedido.PratoR = Convert.ToBoolean(row["PratoR"]);
                pedido.BebidaR = Convert.ToBoolean(row["BebidaR"]);
                pedido.Entregue = Convert.ToBoolean(row["entregue"]);

                return pedido;
            }

            return pedido;
        }

        public void Save()
        {
            // Inicializa a função Save contida no database
            new Database.Pedido().Salvar(this.Id, this.NomeCliente, this.Mesa, this.Prato, this.QtdPrato, this.Bebida, this.QtdBebida, this.PratoR, this.BebidaR, this.Entregue);
        }

        public static void Excluir(int Id)
        {
            // Inicializa a função Excluir contida no database
            new Database.Pedido().Excluir(Id);
        }
    }
}
