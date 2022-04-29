using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IUsuario
    {
        private readonly DbContextOptions<ContextoUsuariosPersonalite> _OptionsBuilder;

        public RepositorioUsuario()
        {
            _OptionsBuilder = new DbContextOptions<ContextoUsuariosPersonalite>();
        }

        public async Task<bool> VerificaUsuarioExiste(Expression<Func<Usuario, bool>> exUsuario)
        {
            using var banco = new ContextoUsuariosPersonalite(_OptionsBuilder);
            return await banco.Usuarios.AnyAsync(exUsuario);
        }

        public async Task<string> RecuperaIdPorEmail(string email)
        {
            using var banco = new ContextoUsuariosPersonalite(_OptionsBuilder);
            var resultado = await banco.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Email == email);
            return resultado.Id.ToString();
        }
    }
}
