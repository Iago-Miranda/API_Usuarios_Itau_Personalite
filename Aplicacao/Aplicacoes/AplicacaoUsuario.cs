using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
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

        public async Task<Usuario> BuscarPorId(Guid Id)
        {
            return await _IUsuario.BuscarPorId(Id);
        }

        public async Task<UsuarioUI> BuscarUsuarioUIPorId(Guid id)
        {
            var usuarioDB = await _IUsuario.BuscarPorId(id);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioUI>());

            var mapper = new Mapper(mappingConfig);

            return mapper.Map<UsuarioUI>(usuarioDB);
        }

        public async Task<List<UsuarioUI>> ListaDeUsuariosUI()
        {
            var usuariosDB = await _IUsuario.ListarTodos();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioUI>());

            var mapper = new Mapper(mappingConfig);

            return mapper.Map<List<UsuarioUI>>(usuariosDB);
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
