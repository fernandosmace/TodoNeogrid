using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using TodoNeogrid.Services;

namespace TodoNeogrid
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var todoService = new TodoService();
            todoService.CriarBancoDeDados();
        }
    }
}