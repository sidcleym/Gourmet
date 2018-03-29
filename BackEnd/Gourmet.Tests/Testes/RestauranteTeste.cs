using Gourmet.ApplicationServices.EscopoValidacao;
using Gourmet.ApplicationServices.Helpers;
using Gourmet.ApplicationServices.Services;
using Gourmet.Domain.Models;
using Gourmet.Persistence.ConexaoHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Gourmet.Tests
{
    [TestClass]
    public class RestauranteTeste
    {
        private RestauranteService  _service;                
              
        private void InicializaConexao()
        {
            TConexao.Open();
            _service          = new RestauranteService(TConexao.unitofWork, TConexao.context);
        }       
        private Restaurante MontaEntidade()
        {
            Restaurante entidade        = new Restaurante();
            entidade.Descricao   = RestauranteHelper.GeraDescricao() +DateTime.Now;
            return entidade;
        }

        private Restaurante SalvaEntidade(bool dispose)
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            var RestauranteSalvo = _service.Salva(entidade);

            if (dispose) TConexao.Dispose();

            return RestauranteSalvo;
        }

        [TestMethod]
        [TestCategory("Restaurante")]
        public void Deve_Salvar_Restaurante()
        {
            InicializaConexao();

            var entidade    = MontaEntidade();            
            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloSalvo, RestauranteEscopo._notificacoes);
        }
        [TestMethod]
        [TestCategory("Restaurante")]
        public void Nao_Deve_Salvar_Restaurante()
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            entidade.Descricao = "";

            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreEqual(null, tituloSalvo, RestauranteEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Restaurante")]
        public void Deve_Atualizar_Restaurante()
        {         
            InicializaConexao();       

            //Busca um Restaurante que foi cadastrado pelo test unitário
            var entidade = (_service.Get() as IQueryable<Restaurante>).ToList().Where(x=> x.Descricao.Contains("TEST")).FirstOrDefault();

            if (entidade == null)
                entidade = SalvaEntidade(false);


            entidade.Descricao     = "TEST UNITARIO "+DateTime.Now;

            var entidadeAtualizada = _service.Atualiza(entidade.Id, entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, entidadeAtualizada, RestauranteEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Restaurante")]
        public void Nao_Deve_Atualizar_Restaurante()
        {
            InicializaConexao();

            //Busca um Restaurante que foi cadastrado pelo test unitário
            var entidade = (_service.Get() as IQueryable<Restaurante>).ToList().Where(x => x.Descricao.Contains("TEST")).FirstOrDefault();

            if (entidade == null)
                entidade = SalvaEntidade(false);


            entidade.Descricao = "";

            var entidadeAtualizada = _service.Atualiza(entidade.Id, entidade);

            TConexao.Dispose();
            Assert.AreEqual(null, entidadeAtualizada, RestauranteEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Restaurante")]
        public void Deve_Buscar_ID()
        {         
            InicializaConexao();

            var entidade = (_service.Get() as IQueryable<Restaurante>).FirstOrDefault();

            if (entidade == null)            
                entidade = SalvaEntidade(false);
            
            var result = _service.Get(entidade.Id);
            
            TConexao.Dispose();
            Assert.AreNotEqual(null, result, RestauranteEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Restaurante")]
        public void Deve_Buscar()
        {         
            InicializaConexao();
 
            var titulos = (_service.Get() as IQueryable<Restaurante>).ToList();

            TConexao.Dispose();
            Assert.AreNotEqual(null, titulos, RestauranteEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Restaurante")]
        public void Deve_Excluir()
        {         
            InicializaConexao();
                                   
            var entidade = SalvaEntidade(false);

            var tituloExcluido = _service.Delete(entidade.Id);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloExcluido, RestauranteEscopo._notificacoes);
        }

                         
    }
}