using System;

namespace Gourmet.Persistence.Infra
{
    public interface IUnitofWork : IDisposable
    {
        object Commit(object objeto);
        void Commit();
    }
}
