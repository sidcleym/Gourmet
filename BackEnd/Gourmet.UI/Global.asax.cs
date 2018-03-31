
using Gourmet.Persistence.Infra;
using System;
using System.Web;

namespace Gourmet.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new DataContext();
         
        }

        
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as DataContext;
            if (entityContext != null)
                entityContext.Dispose();
        }
         
    }
}
