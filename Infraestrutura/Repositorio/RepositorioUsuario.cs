using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IUsuario
    {
        private readonly ContextoUsuariosPersonalite _banco;

        public RepositorioUsuario(ContextoUsuariosPersonalite banco) : base(banco)
        {
            _banco = banco;
        }

        public async Task<bool> VerificaUsuarioExiste(Expression<Func<Usuario, bool>> exUsuario)
        {
            return await _banco.Usuarios.AnyAsync(exUsuario);
        }

        public async Task<Usuario> RecuperaUsuarioPorEmail(string email)
        {
            var resultado = await _banco.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Email == email);
            return resultado;
        }
    }
}
