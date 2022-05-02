using Aplicacao.Aplicacoes;
using Dominio.Interfaces;
using Dominio.Servicos;
using Entidades.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace API_Usuarios_Itau_Personalite.Testes
{
    public class AplicacaoUsuarioTestes
    {
        [Fact]
        public async Task Dado_IdDeUsuarioCadastrado_RetornaUsuarioFormatoUi()
        {
            //Arrange
            var mock = new Mock<IUsuario>();

            var usuarioDummy = new Usuario
            {
                Id = Guid.Empty,
                Email = "emailDummy@teste.com",
                Nome = "usuario dummy",
                Senha = "12345678"
            };

            mock.Setup(repo => repo.BuscarPorId(It.IsAny<Guid>())).Returns(Task.FromResult(usuarioDummy));

            var repositorioUsuarios = mock.Object;

            var aplicacaoUsuario = new AplicacaoUsuario(repositorioUsuarios);

            //Act
            var resultado = await aplicacaoUsuario.BuscarUsuarioUIPorId(usuarioDummy.Id);

            //Assert
            Assert.Equal(usuarioDummy.Id, resultado.Id);
        }

        [Fact]
        public async Task Dado_SolicitacaoDeListaDeUsuariosUi_RetornaListaDeUsuariosUi()
        {
            //Arrange
            var mock = new Mock<IUsuario>();

            var usuarioDummy = new Usuario
            {
                Id = Guid.Empty,
                Email = "emailDummy@teste.com",
                Nome = "usuario dummy",
                Senha = "12345678"
            };

            var listaUsuarioDb = new List<Usuario>()
            {
                usuarioDummy
            };

            mock.Setup(repo => repo.ListarTodos()).Returns(Task.FromResult(listaUsuarioDb));

            var repositorioUsuarios = mock.Object;

            var aplicacaoUsuario = new AplicacaoUsuario(repositorioUsuarios);

            //Act
            var resultado = await aplicacaoUsuario.ListaDeUsuariosUI();

            //Assert
            Assert.Equal(usuarioDummy.Id, resultado[0].Id);
        }

        [Fact]
        public async Task Dada__RequisicaoParaValidarSeUsuarioExiste_VerificaSeUsuarioExiste()
        {
            //Arrange
            var mock = new Mock<IUsuario>();

            mock.Setup(repo => repo.VerificaUsuarioExiste(It.IsAny<Expression<Func<Usuario, bool>>>())).Returns(Task.FromResult(true));

            var repositorioUsuarios = mock.Object;

            var aplicacaoUsuario = new AplicacaoUsuario(repositorioUsuarios);

            //Act
            await aplicacaoUsuario.VerificaUsuarioExiste(usuario => usuario.Id == Guid.Empty);

            //Assert
            mock.Verify(mock => mock.VerificaUsuarioExiste(usuario => usuario.Id == Guid.Empty), Times.Once());
        }

        [Fact]
        public async Task Dado_UsuarioParaSerCriado_RealizaChamadaDeAdicaoNoRepositorio()
        {
            //Arrange
            var mock = new Mock<IUsuario>();

            var usuarioDummy = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = "emailDummy@teste.com",
                Nome = "usuario dummy",
                Senha = "12345678"
            };

            mock.Setup(repo => repo.Adicionar(It.IsAny<Usuario>())).Returns(Task.FromResult(usuarioDummy));

            var repositorioUsuarios = mock.Object;

            var aplicacaoUsuario = new AplicacaoUsuario(repositorioUsuarios);

            //Act
            await aplicacaoUsuario.Adicionar(usuarioDummy);

            //Assert
            mock.Verify(mock => mock.Adicionar(usuarioDummy), Times.Once());
        }
    }
}
