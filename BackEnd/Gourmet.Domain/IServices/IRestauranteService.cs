using Gourmet.Domain.Models;
using System.Linq;

namespace Gourmet.Domain.IServices
{
    public interface IRestauranteService
    {
        IQueryable Get();
        Restaurante Get(int id);
        Restaurante Salva(Restaurante restaurante);
        Restaurante Atualiza(int id, Restaurante restaurante);
        Restaurante Delete(int id);
    }
}
