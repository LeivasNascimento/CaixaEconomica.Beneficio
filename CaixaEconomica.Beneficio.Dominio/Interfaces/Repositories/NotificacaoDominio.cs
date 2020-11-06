using CaixaEconomica.Beneficio.Dominio.Interfaces.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Interfaces.Repositories
{
    public class NotificacaoDominio : INotificacaoDominio 
    {
        private List<string> _erroMensagem = new List<string>();
        private List<string> _avisoMensagem = new List<string>();

        public IEnumerable<string> ErroMensagem => _erroMensagem;

        public IEnumerable<string> AvisoMensagem => _avisoMensagem;

        public void AddAviso(string mensagem)
        {
            _avisoMensagem.Add(mensagem);
        }

        public void AddErro(string mensagem)
        {
            _erroMensagem.Add(mensagem);
        }

        public bool TemAviso()
        {
            return _avisoMensagem.Any();
        }

        public bool Validado()
        {
            return !_erroMensagem.Any();
        }
    }
}
