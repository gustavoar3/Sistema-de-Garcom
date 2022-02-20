using System.Web.Mvc;

// Controller da página Home ou Index
namespace Sistema_de_Gracom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}