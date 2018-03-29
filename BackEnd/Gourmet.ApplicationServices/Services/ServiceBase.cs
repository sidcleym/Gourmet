using Gourmet.Persistence.Infra;
using Gourmet.Shared.Notificacoes;

namespace Gourmet.ApplicationServices.Services
{
    public class ServiceBase
    {
        private IUnitofWork _unitOfWork;
        private IManipulador<DominioNotificacoes> _notifications;

        public ServiceBase()
        {

        }
        public ServiceBase(IUnitofWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DominioEvento.Container.GetService<IManipulador<DominioNotificacoes>>();
        }

        public object Commit(object objeto = null)
        {
            if (_notifications.temNotificacoes())
                return null;
            
            return _unitOfWork.Commit(objeto);
           // return true;
        }


        public bool Commit()
        {
            if (_notifications.temNotificacoes())
                return false;
            
            _unitOfWork.Commit();
            return true;
        }
    }
}
