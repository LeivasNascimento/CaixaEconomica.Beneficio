using CaixaEconomica.Beneficio.Dominio.Interfaces.Notification;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
    //abstract: n pode ser instanciada
    public abstract class Entidade
    {
        private INotificacaoDominio _notificacaoDominio;

        protected INotificacaoDominio NotificacaoDominio
        {
            get
            {
                return _notificacaoDominio == null ?
                    throw new System.Exception("erro: NotificacaoDominio não foi instanciado. Favor chamar o metodo de setar") :
                    _notificacaoDominio;
            }
        }

        public void SetNotificacao(INotificacaoDominio notificacaoDominio)
        {
            _notificacaoDominio = notificacaoDominio;
        }

        public bool Valido()
        {
            return _notificacaoDominio.Validado();
        }


        public Entidade()
        {

        }
    }
}
