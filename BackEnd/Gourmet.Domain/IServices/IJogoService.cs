using Gourmet.Domain.Models;
using System.Linq;

namespace Gourmet.Domain.IServices
{
    public interface IPratoService
    {
        IQueryable Get();
        Prato Get(int id);
        Prato Salva(Prato prato);
        Prato Atualiza(int id, Prato prato);        
        Prato Delete(int id);
    }
}
