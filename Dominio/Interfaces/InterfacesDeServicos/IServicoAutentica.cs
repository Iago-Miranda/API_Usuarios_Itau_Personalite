using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesDeServicos
{
    public interface IServicoAutentica
    {
        public Task<bool> ValidaCredenciais(string emailUsuario, string senhaUsuario);
    }
}
