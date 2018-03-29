using System;
using System.Collections.Generic;

namespace Gourmet.Shared.Notificacoes
{
    public interface IManipulador<T> : IDisposable where T : IDominioEvento
    {
        void Manipula(T args);
        IEnumerable<T> Notifica();
        bool temNotificacoes();
    }
}
