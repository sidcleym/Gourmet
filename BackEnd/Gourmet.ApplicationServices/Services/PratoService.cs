
using Gourmet.ApplicationServices.EscopoValidacao;
using Gourmet.Domain.IEscopo;
using Gourmet.Domain.IRepository;
using Gourmet.Domain.IServices;
using Gourmet.Domain.Models;
using Gourmet.Domain.Repository;
using Gourmet.Persistence.Infra;
using System;
using System.Linq;

namespace Gourmet.ApplicationServices.Services
{
    public class PratoService :ServiceBase, IPratoService
    {
        private readonly IRepositorioBase<Prato> _repositorioPrato;
        private DataContext _context;

        public PratoService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {            
            this._repositorioPrato = new RepositorioBase<Prato>(context);
            this._context            = context;
        }
        
        public void GerenciarVirtuais(Prato prato)
        {
            prato.RestauranteId = (prato.Restaurante != null) ? prato.Restaurante.Id : prato.RestauranteId;
            prato.Restaurante = null;

        }
        public IQueryable Get()
        {
            return this._repositorioPrato.Get().Include("Restaurante") as IQueryable;
        }
        
        public Prato Get(int id)
        {
            var Prato   = _repositorioPrato.Get().Include("Restaurante")
                .Where(x => x.Id == id).First();
           
            if (Prato == null)
                throw new Exception("Prato inexistente");

            return Prato;
        }
        
        public Prato Salva(Prato PratoPostado)
        {
            PratoPostado.DtInclusao      = DateTime.Now;
            this.GerenciarVirtuais(PratoPostado);

            PratoEscopo.SalvarIsValid(PratoPostado);
            
            _repositorioPrato.Save(PratoPostado);

            if (Commit())
                return PratoPostado;

            return null;
        }

      

        public Prato Atualiza(int id, Prato pratoPostado )
        {

            var prato = _repositorioPrato.Get().AsNoTracking().Where(x=> x.Id == id).FirstOrDefault();

            if (prato == null)
                throw new Exception("Prato inexistente");

            GerenciarVirtuais(pratoPostado);

            pratoPostado.Id = id;            
            pratoPostado.DtInclusao = prato.DtInclusao;
            pratoPostado.DtAtualizacao = DateTime.Now;

            PratoEscopo.AtualizarIsValid(pratoPostado);

            _repositorioPrato.Update(pratoPostado);
            if (Commit())
                return prato;

            return null;
        }
        
        public Prato Delete(int id)
        {
            var Prato = this._repositorioPrato.Get(id);

            if (Prato == null)
            {
                PratoEscopo.CriaNotificacao("Ação inválida","Usuário inexistente");
                return null;
            }
           
			if(!PratoEscopo.ExcluirIsValid(Prato))
				return null;

            this._repositorioPrato.Delete(Prato);
            
            if (Commit())
                return Prato;

            return null;
        }

    }
}
