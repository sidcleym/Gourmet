
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
        
        public IQueryable Get()
        {
            return this._repositorioPrato.Get() as IQueryable;
        }
        
        public Prato Get(int id)
        {
            var Prato   = _repositorioPrato.Get()
                .Where(x => x.Id == id).First();
           
            if (Prato == null)
                throw new Exception("Prato inexistente");

            return Prato;
        }
        
        public Prato Salva(Prato PratoPostado)
        {
            PratoPostado.DtInclusao      = DateTime.Now;

            PratoEscopo.SalvarIsValid(PratoPostado);
            
            _repositorioPrato.Save(PratoPostado);

            if (Commit())
                return PratoPostado;

            return null;
        }

      

        public Prato Atualiza(int id, Prato PratoPostado )
        {

            Prato Prato = _repositorioPrato.Get().AsNoTracking().Where(x=> x.Id == id).FirstOrDefault();
            if (Prato == null)
                throw new Exception("Prato inexistente");

            PratoPostado.Id = id;
            PratoPostado.DtInclusao = Prato.DtInclusao;
            PratoPostado.DtAtualizacao = DateTime.Now;

            PratoEscopo.AtualizarIsValid(PratoPostado);

            _repositorioPrato.Update(PratoPostado);
            if (Commit())
                return Prato;

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
