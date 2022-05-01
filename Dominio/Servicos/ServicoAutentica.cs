using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesDeServicos;
using System;
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
            var usuarioLocalizado = await _IUsuario.RecuperaUsuarioPorEmail(email);

            return usuarioLocalizado is null ? Guid.Empty.ToString() : usuarioLocalizado.Id.ToString();
        }
    }
}
