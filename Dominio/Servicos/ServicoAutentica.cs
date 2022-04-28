using Dominio.Interfaces;
using Dominio.Interfaces.InterfacesDeServicos;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await _IUsuario.VerificaUsuarioExiste(usuario => usuario.Email == emailUsuario 
                                                                        && usuario.Senha == senhaUsuario);
        }
    }
}
