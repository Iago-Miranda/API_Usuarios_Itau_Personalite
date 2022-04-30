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
        private readonly ContextoUsuariosPersonalite _banco;

        public RepositorioUsuario(ContextoUsuariosPersonalite banco) : base(banco)
        {
            _banco = banco;
        }

        public async Task<bool> VerificaUsuarioExiste(Expression<Func<Usuario, bool>> exUsuario)
        {
            return await _banco.Usuarios.AnyAsync(exUsuario);
        }

        public async Task<string> RecuperaIdPorEmail(string email)
        {
            var resultado = await _banco.Usuarios.AsNoTracking().FirstOrDefaultAsync(usuario => usuario.Email == email);
            return resultado.Id.ToString();
        }
    }
}
