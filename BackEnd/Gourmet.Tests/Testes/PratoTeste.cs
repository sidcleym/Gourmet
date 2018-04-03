using EmprestimoJogos.Domain.Helpers;
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
    public class PratoTeste
    {
        private string  dataCorrente             = Convert.ToString(DateTime.Now);
        private PratoService  _service;
        private RestauranteService _serviceRestaurante;

        private void InicializaConexao()
        {
            TConexao.Open();
            _service          = new PratoService(TConexao.unitofWork, TConexao.context);
            _serviceRestaurante = new RestauranteService(TConexao.unitofWork, TConexao.context);
        }       
        private Prato MontaEntidade()
        {
            Prato entidade  = new Prato();
            entidade.Descricao   = PratoHelper.primeiroNome()+" "+ PratoHelper.sobreNome1();
            entidade.Preco = 100;
            entidade.Observacao = "TESTE UNIT. " + DateTime.Now;

            var restaurante = TConexao.context.Restaurante.FirstOrDefault();
            if (restaurante == null) {
                restaurante = new Restaurante() {Descricao = RestauranteHelper.GeraDescricao() };
                restaurante = _serviceRestaurante.Salva(restaurante);
                
            }
            entidade.Restaurante = restaurante;
            return entidade;
        }

        private Prato SalvaEntidade(bool dispose)
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            var PratoSalvo = _service.Salva(entidade);

            if (dispose) TConexao.Dispose();

            return PratoSalvo;
        }

        [TestMethod]
        [TestCategory("Prato")]
        public void Deve_Salvar_Prato()
        {
            InicializaConexao();

            var entidade    = MontaEntidade();            
            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloSalvo, PratoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Prato")]
        public void Nao_Deve_Salvar_Prato()
        {
            InicializaConexao();

            var entidade = MontaEntidade();
            entidade.Preco = 0;

            var tituloSalvo = _service.Salva(entidade);

            TConexao.Dispose();
            Assert.AreEqual(null, tituloSalvo, PratoEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Prato")]
        public void Deve_Atualizar_Prato()
        {         
            InicializaConexao();       

            var entidade = (_service.Get() as IQueryable<Prato>).Where(x=> x.Observacao.Contains("TEST")).FirstOrDefault();

            if (entidade == null)
                entidade = SalvaEntidade(false);


            entidade.Descricao     = "TEST UNITARIO "+DateTime.Now;

            TConexao.Dispose();
            InicializaConexao();
            var entidadeAtualizada = _service.Atualiza(entidade.Id, entidade);

            TConexao.Dispose();
            Assert.AreNotEqual(null, entidadeAtualizada, PratoEscopo._notificacoes);
        }
        
        
        [TestMethod]
        [TestCategory("Prato")]
        public void Deve_Buscar_ID()
        {         
            InicializaConexao();

            var entidade = (_service.Get() as IQueryable<Prato>).FirstOrDefault();

            if (entidade == null)            
                entidade = SalvaEntidade(false);
            
            var result = _service.Get(entidade.Id);
            
            TConexao.Dispose();
            Assert.AreNotEqual(null, result, PratoEscopo._notificacoes);
        }

        [TestMethod]
        [TestCategory("Prato")]
        public void Deve_Buscar()
        {         
            InicializaConexao();
 
            var titulos = (_service.Get() as IQueryable<Prato>).ToList();

            TConexao.Dispose();
            Assert.AreNotEqual(null, titulos, PratoEscopo._notificacoes);
        }


        [TestMethod]
        [TestCategory("Prato")]
        public void Deve_Excluir()
        {         
            InicializaConexao();
                                   
            var entidade = SalvaEntidade(false);

            var tituloExcluido = _service.Delete(entidade.Id);

            TConexao.Dispose();
            Assert.AreNotEqual(null, tituloExcluido, PratoEscopo._notificacoes);
        }

                         
    }
}