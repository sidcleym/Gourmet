using Gourmet.Domain.IServices;
using Gourmet.Domain.Models;
using Gourmet.Shared.Notificacoes;
using Gourmet.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Gourmet.UI.Controllers
{

    [RoutePrefix("api/restaurante")]
    public class RestauranteController : ControllerBase
    {
        private HttpResponseMessage _response = new HttpResponseMessage();
        private readonly IRestauranteService _service;



        public RestauranteController(IRestauranteService service)
        {
            this._service = service;
        }


        [HttpGet]
        [Route("")]        
        public Task<HttpResponseMessage> Get()
        {
            try
            {
                //TControleAcesso.Executa(User, TMapeamentoRotinas.EST_ARMAZEM_EXIBIR, "");

                var entidade = _service.Get() as IQueryable<Restaurante>;

                //Resposta Resposta = new Resposta(true, null, entidade);
                this._response = Request.CreateResponse(HttpStatusCode.OK, entidade);

                //TAuditoria.RegistraAcesso(entidade);
            }
            catch (Exception ex)
            {
                //Erros erro = Texcecao.create(ex);
                this._response = Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return CreateResponse(this._response);
        }
    }
}
