using Business;
using System.Web.Mvc;

// Controller das páginas Garcom, Cozinha e Copa
namespace Sistema_de_Gracom.Controllers
{
    public class RestauranteController : Controller
    {
        public ActionResult Garcom()
        {
            ViewBag.Cardapio = new Menu().Lista();
            ViewBag.Pedidos = new Pedido().Lista();

            return View();
        }

        public ActionResult Cozinha()
        {
            ViewBag.Cardapio = new Pedido().Lista();

            return View();
        }

        public ActionResult Copa()
        {
            ViewBag.Cardapio = new Pedido().Lista();

            return View();
        }
    }
}
