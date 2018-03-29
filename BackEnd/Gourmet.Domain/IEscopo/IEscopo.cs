using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Domain.IEscopo
{
    public interface IEscopoValidacao<T>
    {
        bool SalvarIsValid(T Entity);
        bool AtualizarIsValid(T Entity);
    }
}
