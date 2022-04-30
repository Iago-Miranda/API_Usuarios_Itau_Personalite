using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoAutentica
    {
        public Task<bool> ValidaCredenciais(string emailUsuario, string senhaUsuario);
        public Task<string> RecuperaIdPorEmail(string email);
    }
}
