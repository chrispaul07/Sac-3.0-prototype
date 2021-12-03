using System.Web;
using System.Web.Mvc;

namespace Sac_3._0_prototype
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
