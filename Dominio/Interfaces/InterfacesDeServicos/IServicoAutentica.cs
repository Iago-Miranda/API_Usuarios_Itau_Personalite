using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfacesDeServicos
{
    public interface IServicoAutentica
    {
        public Task<bool> ValidaCredenciais(string emailUsuario, string senhaUsuario);
        public Task<string> RecuperaIdPorEmail(string email);
    }
}
