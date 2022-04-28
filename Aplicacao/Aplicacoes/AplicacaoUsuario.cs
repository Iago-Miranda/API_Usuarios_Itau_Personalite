using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        private readonly IUsuario _IUsuario;

        public AplicacaoUsuario(IUsuario IUsuario)
        {
            _IUsuario = IUsuario;
        }

        public async Task Adicionar(Usuario Objeto)
        {
            await _IUsuario.Adicionar(Objeto);
        }

        public async Task<Usuario> BuscarPorId(int Id)
        {
            return await _IUsuario.BuscarPorId(Id);
        }

        public async Task<List<Usuario>> ListarTodos()
        {
            return await _IUsuario.ListarTodos();
        }

        public async Task<bool> VerificaUsuarioExiste(Expression<Func<Usuario, bool>> exUsuario)
        {
            return await _IUsuario.VerificaUsuarioExiste(exUsuario);
        }
    }
}
