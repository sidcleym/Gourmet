using System.Web.Http;
using WebActivatorEx;
using Gourmet.UI;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Gourmet.UI
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Gourmet.UI")
                .License(l =>
                {
                    l.Name("Mit");
                    l.Url("http://localhost:2020/api/v1/faturamento/documentosaida");
                });


            }).EnableSwaggerUi(c=> {
                
            });


        }
    }
}
