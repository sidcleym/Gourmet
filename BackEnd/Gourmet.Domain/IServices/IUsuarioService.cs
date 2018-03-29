using Gourmet.Domain.Models;
using System.Linq;

namespace Gourmet.Domain.IServices
{
    public interface IUsuarioService
    {
        IQueryable Get();
        Usuario Get(int id);
        Usuario Get(string login);
        Usuario Salva(Usuario usuario);
        Usuario Atualiza(int id, Usuario usuario);
        
        Usuario Delete(int id);
        bool isLoginValid(string login, string senha);
    }
}
