using Dominio.Interfaces;
using Dominio.Servicos;
using Entidades.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace API_Usuarios_Itau_Personalite.Testes
{
    public class ServicoAutenticaTestes
    {
        [Fact]
        public async Task Dadas_CredenciaisValidas_RetornaStatusDeLoginValido()
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

            var listaUsuariosDummy = new List<Usuario>()
            {
                usuarioDummy
            };

            mock.Setup(repo => repo.ListarTodos()).Returns(Task.FromResult(listaUsuariosDummy));

            var repositorioUsuarios = mock.Object;

            var servicoAutentica = new ServicoAutentica(repositorioUsuarios);

            //Act
            var resultado = await servicoAutentica.ValidaCredenciais(usuarioDummy.Email, usuarioDummy.Senha);

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task Dadas_CredenciaisInvalidas_RetornaStatusDeLoginInvalido()
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

            var listaUsuariosDummy = new List<Usuario>()
            {
                usuarioDummy
            };

            mock.Setup(repo => repo.ListarTodos()).Returns(Task.FromResult(listaUsuariosDummy));

            var repositorioUsuarios = mock.Object;

            var servicoAutentica = new ServicoAutentica(repositorioUsuarios);

            //Act
            var resultado = await servicoAutentica.ValidaCredenciais("emailIncorreto@teste.com", usuarioDummy.Senha);

            //Assert
            Assert.False(resultado);
        }

        [Fact]
        public async Task Dado_EmailDoUsuarioExistente_RetornaIdDoUsuario()
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

            mock.Setup(repo => repo.RecuperaUsuarioPorEmail(It.IsAny<string>())).Returns(Task.FromResult(usuarioDummy));

            var repositorioUsuarios = mock.Object;

            var servicoAutentica = new ServicoAutentica(repositorioUsuarios);

            //Act
            var resultado = await servicoAutentica.RecuperaIdPorEmail(usuarioDummy.Email);

            //Assert
            Assert.Equal(usuarioDummy.Id.ToString(), resultado);
        }

        [Fact]
        public async Task Dado_EmailDoUsuarioInexistente_RetornaIdVazio()
        {
            //Arrange
            var mock = new Mock<IUsuario>();

            Usuario usuarioDummy = null;

            mock.Setup(repo => repo.RecuperaUsuarioPorEmail(It.IsAny<string>())).Returns(Task.FromResult(usuarioDummy));

            var repositorioUsuarios = mock.Object;

            var servicoAutentica = new ServicoAutentica(repositorioUsuarios);

            //Act
            var resultado = await servicoAutentica.RecuperaIdPorEmail("emailTeste@teste.com");

            //Assert
            Assert.Equal(Guid.Empty.ToString(), resultado);
        }
    }
}
