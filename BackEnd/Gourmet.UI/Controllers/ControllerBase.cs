using Gourmet.Shared.Notificacoes;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gourmet.UI.Controllers
{
    public class ControllerBase : ApiController
    {
        public IManipulador<DominioNotificacoes> Notifications;
        public HttpResponseMessage ResponseMessage;

        public ControllerBase()
        {
            this.Notifications   = DominioEvento.Container.GetService<IManipulador<DominioNotificacoes>>();
            this.ResponseMessage = new HttpResponseMessage();           
        }

        public Task<HttpResponseMessage> CreateResponse(HttpResponseMessage result)
        {
            if (Notifications.temNotificacoes()){
                ResponseMessage = Request.CreateResponse(result.StatusCode, Notifications.Notifica());
                result = ResponseMessage;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(result);
            return tsc.Task;
        }

        

        protected override void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }
    }
}
