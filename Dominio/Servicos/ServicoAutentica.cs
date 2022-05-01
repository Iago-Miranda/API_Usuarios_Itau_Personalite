using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesDeServicos;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoAutentica : IServicoAutentica
    {
        private readonly IUsuario _IUsuario;

        public ServicoAutentica(IUsuario IUsuario)
        {
            _IUsuario = IUsuario;
        }

        public async Task<bool> ValidaCredenciais(string emailUsuario, string senhaUsuario)
        {
            var listaUsuarios = await _IUsuario.ListarTodos();

            return listaUsuarios.Any(usuario => usuario.Email == emailUsuario 
                                                                        && usuario.Senha == senhaUsuario);
        }
        public async Task<string> RecuperaIdPorEmail(string email)
        {
            return await _IUsuario.RecuperaIdPorEmail(email);
        }
    }
}
