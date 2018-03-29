using Gourmet.ApplicationServices.EscopoValidacao;
using Gourmet.ApplicationServices.Services;
using Gourmet.Domain.IRepository;
using Gourmet.Domain.IServices;
using Gourmet.Domain.Models;
using Gourmet.Domain.Repository;
using Gourmet.Persistence.Infra;
using System;
using System.Linq;

namespace Gourmet.ApplicationServices.Services
{
    public class RestauranteService : ServiceBase, IRestauranteService
    {
        private readonly IRepositorioBase<Restaurante> _repositorioRestaurante;
        private readonly DataContext _context;


        public RestauranteService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {
            this._context               = context;
            this._repositorioRestaurante      = new RepositorioBase<Restaurante>(context);
        }
       
        public IQueryable Get()
        {
            return this._repositorioRestaurante.Get() as IQueryable;
        }

        public Restaurante Get(int id)
        {
            var Restaurante   = _repositorioRestaurante.Get(id);
           
            if (Restaurante == null)
                throw new Exception("Usuário inexistente");

            return Restaurante;
        }

        

        public Restaurante Salva(Restaurante restaurantePostado)
        {
            restaurantePostado.DtInclusao      = DateTime.Now;

            RestauranteEscopo.SalvarIsValid(restaurantePostado);
            

            _repositorioRestaurante.Save(restaurantePostado);

            if (!Commit())
                return null;

            return restaurantePostado;
        }

        public Restaurante Atualiza(int id, Restaurante RestaurantePostado )
        {

            Restaurante Restaurante = _repositorioRestaurante.Get().AsNoTracking().Where(x=> x.Id==id).FirstOrDefault();
            if (Restaurante == null)
                throw new Exception("Restaurante inexistente");

            RestaurantePostado.Id            = id;
            RestaurantePostado.DtInclusao    = Restaurante.DtInclusao;
            RestaurantePostado.DtAtualizacao = DateTime.Now;
            RestauranteEscopo.AtualizarIsValid(RestaurantePostado);

            _repositorioRestaurante.Update(RestaurantePostado);
            if (!Commit())
                return null;

            return RestaurantePostado;
        }

       

        public Restaurante Delete(int id)
        {

            var restaurante = this.Get(id);

            _repositorioRestaurante.Delete(restaurante);

            if (!Commit())
                    return null;

            return restaurante;
            
        }
    }
}
