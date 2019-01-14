using System.Web;
using System.Web.Mvc;

namespace ASP_hw2_OnlineShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
