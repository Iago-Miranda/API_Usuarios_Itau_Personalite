using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesDeServicos;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoAutentica : IAplicacaoAutentica
    {
        private readonly IServicoAutentica _IServicoAutentica;

        public AplicacaoAutentica(IServicoAutentica IServicoAutentica)
        {
            _IServicoAutentica = IServicoAutentica;
        }

        public async Task<bool> ValidaCredenciais(string emailUsuario, string senhaUsuario)
        {
            return await _IServicoAutentica.ValidaCredenciais(emailUsuario,senhaUsuario);
        }

        public async Task<string> RecuperaIdPorEmail(string email)
        {
            return await _IServicoAutentica.RecuperaIdPorEmail(email);
        }
    }
}
