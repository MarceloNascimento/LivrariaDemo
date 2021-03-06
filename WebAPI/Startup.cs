﻿
using Infra.Mappers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(APIServices.Startup))]

namespace APIServices
{


    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            var formatters = config.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());

            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //// Serviços e configuração da API da Web
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            AutoMapperConfig.RegisterMappings();

        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            //kernel.Bind<IUnitOfWorkService>().To<UnitOfWorkService>();
            //kernel.Bind<ICategoriaAppService>().To<CategoriaAppService>();
            //kernel.Bind<IContatoAppService>().To<ContatoAppService>();
            //kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {

           
        }


    }
}
