using Gourmet.Persistence.Infra;
using Gourmet.Shared.Notificacoes;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;

namespace Gourmet.Persistence.ConexaoHelper
{
    public static class TConexao
    {
        public static DataContext context;        
        public static UnitofWork  unitofWork;
        public static IManipulador<DominioNotificacoes> notifications;
        
        public static void ResolveDependencias()
        {
            // HttpConfiguration config  = new HttpConfiguration();
            var container                = new UnityContainer();
            container.RegisterType<IManipulador<DominioNotificacoes>, DominioNotificacoesManipulador>(new HierarchicalLifetimeManager());
            var DependencyResolver       = new UnityResolver(container);
            DominioEvento.Container      = new DominioEventosContainer(DependencyResolver);
        }

        public static void Open()
        {
           ResolveDependencias();          
           context    = new DataContext();           
           unitofWork = new UnitofWork(context);
        }

        public static IList<DominioNotificacoes> Notificacoes()
        {
            notifications = DominioEvento.Container.GetService<IManipulador<DominioNotificacoes>>();

            return notifications.Notifica().ToList();
        }

        public static void Dispose(){
            context.Dispose();
        }
    }
}
