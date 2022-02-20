using System.Web;
using System.Web.Mvc;

namespace Sistema_Para_Gracom
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
