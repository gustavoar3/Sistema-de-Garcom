using Business;
using System;
using System.Web.Mvc;

// Controller das paginas FazerPedido, e Entregue
namespace Sistema_de_Gracom.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult FazerPedido()
        {
            ViewBag.Cardapio = new Menu().Lista();

            return View();
        }

        [HttpPost]
        public void Novo()
        {
            // Armazena os valores preenchidos no forms FazorPedido
            var pedido = new Pedido();

            pedido.NomeCliente = Request["nome"];
            pedido.Mesa = Convert.ToInt32(Request["mesa"]);

            pedido.Prato = Request["prato"];
            pedido.QtdPrato = Convert.ToInt32(Request["qtdprato"]);
            if (pedido.Prato == "Nenhum") pedido.QtdPrato = 0;

            pedido.Bebida = Request["bebida"];
            pedido.QtdBebida = Convert.ToInt32(Request["qtdbebida"]);
            if (pedido.Bebida == "Nenhum") pedido.QtdBebida = 0;

            pedido.PratoR = ValidaCampo(pedido.Prato, pedido.QtdPrato);
            pedido.BebidaR = ValidaCampo(pedido.Bebida, pedido.QtdBebida);

            pedido.Entregue = false;
            if (pedido.PratoR && pedido.BebidaR) pedido.Entregue = true;

            // Salva na tabela
            pedido.Save();

            Response.Redirect("/garcom");
        }

        private bool ValidaCampo(string tipo, int qtd)
        {
            // Verifica caso os valores de Prato/Bebida ou QtdPrato/QtdBebida são nulos, pois assim já os marcam como preparados automaticamente
            if (tipo == "Nenhum" || qtd == 0) return true;

            return false;
        }

        public ActionResult Entregue()
        {
            ViewBag.Cardapio = new Pedido().Lista();

            return View();
        }

        public void EntregarPrato(int id)
        {
            // Procura o id do prato solicitado e então o marca como Ready
            var pedido = Pedido.BuscaPorId(id);
            pedido.PratoR = true;

            pedido.Save();

            Response.Redirect("/cozinha");
        }

        public void EntregarBebida(int id)
        {
            // Procura o id da bebida solicitada e então a marca como Ready
            var pedido = Pedido.BuscaPorId(id);
            pedido.BebidaR = true;

            pedido.Save();

            Response.Redirect("/copa");
        }

        public void EntregarTotal(int id)
        {
            // Procura o id do pedido e o marca como Entregue
            var pedido = Pedido.BuscaPorId(id);
            pedido.Entregue = true;

            pedido.Save();

            Response.Redirect("/garcom");
        }

        public void Excluir(int id)
        {
            // Executa a função excluir para retirar os dados do id da tabela
            Pedido.Excluir(id);

            Response.Redirect("/pedido/entregues");
        }

    }
}
