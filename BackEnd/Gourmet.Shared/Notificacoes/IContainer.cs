﻿using System;
using System.Collections.Generic;

namespace Gourmet.Shared.Notificacoes
{

    public interface IContainer
    {
        T GetService<T>();
        object GetService(Type serviceType);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type serviceType);
    }
    
}
