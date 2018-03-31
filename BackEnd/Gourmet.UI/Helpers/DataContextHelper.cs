
using Gourmet.Persistence.Infra;
using System.Web;

namespace Gourmet.UI.Helpers
{
    public static class DataContextHelper
    {
        public static DataContext CurrentDataContext
        {
            get { return HttpContext.Current.Items["_EntityContext"] as DataContext; }
        }
       
    }
}