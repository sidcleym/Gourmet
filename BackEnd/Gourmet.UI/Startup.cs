
using Gourmet.ApplicationServices.Services;
using Gourmet.Domain.IServices;
using Gourmet.Persistence.Infra;
using Gourmet.Shared.Notificacoes;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Gourmet.UI.Helpers;
using System;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Swashbuckle.Application;

namespace Gourmet.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //DataContext.connectionString = HttpContext.Current.Request.Url.Host;
            var config = new HttpConfiguration()
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always // Add this line to enable detail mode in release
            };

            
            var container = new UnityContainer();

            //ConfigureOAuth(app);
            RegisterRoutes(config);
            app.UseCors(CorsOptions.AllowAll);

            config.MessageHandlers
             .Insert(0, new ServerCompressionHandler(
                 new GZipCompressor(),
                 new DeflateCompressor())
             );


            app.UseWebApi(config);
            ConfigureDependencyInjection(config, container);
            ConfigureJsonSerialization(config);

            SwaggerConfig.Register(config);
            
        }

        

        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            Register( container);
            config.DependencyResolver = new UnityResolver(container);
            DominioEvento.Container   = new DominioEentosContainer(config.DependencyResolver);
        }

        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        private static void Register( UnityContainer container)
        {
            container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IManipulador<DominioNotificacoes>, DominioNotificacoesManipulador>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitofWork, UnitofWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestauranteService, RestauranteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoService, PratoService>(new HierarchicalLifetimeManager());


        }

        private void ConfigureJsonSerialization(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings              = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting       = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();            

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling   = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            jsonSettings.DateParseHandling    = DateParseHandling.None;
            jsonSettings.DateFormatHandling   = DateFormatHandling.IsoDateFormat;
            jsonSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        }

        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Empresa>("Empresa");

           // builder.EntitySet<Cidade>("Cidade");
           // builder.EntitySet<Cliente>("odata");
            // builder.SENavigationSources;
            config.EnableEnumPrefixFree(enumPrefixFree: true);
          
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "api/{controller}",
                model: builder.GetEdmModel()
            );

        }


    }
}