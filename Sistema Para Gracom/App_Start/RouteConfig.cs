using System.Web.Mvc;
using System.Web.Routing;

// Arquivo para configuração dos urls
namespace Sistema_de_Gracom
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "copa",
                "copa",
                new { controller = "Restaurante", action = "Copa" }
            );

            routes.MapRoute(
                "cozinha",
                "cozinha",
                new { controller = "Restaurante", action = "Cozinha" }
            );

            routes.MapRoute(
                "garcom",
                "garcom",
                new { controller = "Restaurante", action = "Garcom" }
            );

            routes.MapRoute(
                "pedido_criar",
                "pedido/criar",
                new { controller = "Pedido", action = "Novo" }
            );

            routes.MapRoute(
                "pedido_novo",
                "pedido/novo",
                new { controller = "Pedido", action = "FazerPedido" }
            );

            routes.MapRoute(
                "pedido_entregues",
                "pedido/entregues",
                new { controller = "Pedido", action = "Entregue" }
            );

            routes.MapRoute(
                "pedido_alterar_prato",
                "pedido/{id}/prato",
                new { controller = "Pedido", action = "EntregarPrato", id = 0 }
            );

            routes.MapRoute(
                "pedido_alterar_bebida",
                "pedido/{id}/bebida",
                new { controller = "Pedido", action = "EntregarBebida", id = 0 }
            );

            routes.MapRoute(
                "pedido_entregar",
                "pedido/{id}/tudo",
                new { controller = "Pedido", action = "EntregarTotal", id = 0 }
            );

            routes.MapRoute(
                "pedido_excluir",
                "pedido/{id}/excluir",
                new { controller = "Pedido", action = "Excluir", id = 0 }
            );

            routes.MapRoute(
                "entrar",
                "entrar",
                new { controller = "Home", action = "Entrar" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
