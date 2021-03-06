using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUsuario : IGenericos<Usuario>
    {
        public Task<bool> VerificaUsuarioExiste(Expression<Func<Usuario, bool>> exUsuario);

        public Task<Usuario> RecuperaUsuarioPorEmail(string email);
    }
}
