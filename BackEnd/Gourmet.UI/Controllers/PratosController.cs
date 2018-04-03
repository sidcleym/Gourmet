using Gourmet.Domain.IServices;
using Gourmet.Domain.Models;
using Gourmet.Shared.Notificacoes;
using Gourmet.UI.Controllers;
using Gourmet.UI.Helpers;
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

    [RoutePrefix("api/pratos")]
    public class PratosController : ControllerBase
    {
        private HttpResponseMessage _response = new HttpResponseMessage();
        private readonly IPratoService _service;

        
        public PratosController(IPratoService service)
        {
            this._service = service;
        }


        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> Get()
        {
            try
            {
                var entidade = _service.Get() as IQueryable<Prato>;

                Resposta.VerificaRetorno(true, entidade);
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, entidade);
                
            }
            catch (Exception ex)
            {                
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, ex);
            }

            return CreateResponse(this._response);
        }


        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            try
            {

                var entidade = _service.Get(id);

                Resposta.VerificaRetorno(true, entidade);
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, entidade);

            }
            catch (Exception ex)
            {
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, ex);
            }

            return CreateResponse(this._response);
        }



        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Salvar(Prato Prato)
        {
            try
            {

                var entidade = _service.Salva(Prato);

                Resposta.VerificaRetorno(true, entidade);
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, entidade);
               
            }
            catch (Exception ex)
            {
                this._response = Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return CreateResponse(this._response);
        }


        [HttpPut]
        [Route("{id}")]
        public Task<HttpResponseMessage> Atualizar(int id, Prato Prato)
        {
            try
            {
                var entidade = _service.Atualiza(id, Prato);

                Resposta.VerificaRetorno(true, entidade);
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, entidade);

            }
            catch (Exception ex)
            {
                this._response = Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return CreateResponse(this._response);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<HttpResponseMessage> Excluir(int id)
        {
            try
            {
                var entidade = _service.Delete(id);

                Resposta.VerificaRetorno(true, entidade);
                this._response = Request.CreateResponse(TRespostaHttp.StatusCode, entidade);

            }
            catch (Exception ex)
            {
                this._response = Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            return CreateResponse(this._response);
        }


    }
}
