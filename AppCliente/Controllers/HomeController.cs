

namespace AppCliente.Controllers
{
    using System;
    using System.Net.Http;
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Página Default do SPA
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["servercli"]; 
         
            return View();
        }
        
    }
}