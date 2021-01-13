using Business.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INotificador
    {
        void Handle(Notificacao notificacao);

        List<Notificacao> ObterNotificacoes();

        bool TemNotificacao();
    }
}