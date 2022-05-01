using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using WebAPIAutenticacao.AuthToken;
using WebAPIAutenticacao.Models;
using WebAPIAutenticacao.Validadores;

namespace WebAPIAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAplicacaoAutentica _IAplicacaoAutentica;
        private readonly IConfiguration _IConfiguration;

        public LoginController(IAplicacaoAutentica IAplicacaoAutentica, IConfiguration IConfiguration)
        {
            _IAplicacaoAutentica = IAplicacaoAutentica;
            _IConfiguration = IConfiguration;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("CriarToken")]
        public async Task<IActionResult> CriarToken([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return Unauthorized();

            ValidadorLogin validador = new ValidadorLogin();

            var resultadoValidacao = validador.Validate(login);

            if (!resultadoValidacao.IsValid)
                return Unauthorized(resultadoValidacao.Errors);

            var resultadoAutenticacao = await _IAplicacaoAutentica.ValidaCredenciais(login.Email, login.Senha);

            if (!resultadoAutenticacao)
                return Unauthorized();

            var idUsuario = await _IAplicacaoAutentica.RecuperaIdPorEmail(login.Email);

            var tokenParaRetornar = new TokenJwtBuilder()
                                            .AddSecurityKey(JwtSecurityKey.Create(_IConfiguration.GetSection("AutenticacaoConfig:TokenSecret").Value))
                                            .AddSubject(_IConfiguration.GetSection("AutenticacaoConfig:TokenSubject").Value)
                                            .AddIssuer(_IConfiguration.GetSection("AutenticacaoConfig:TokenIssuer").Value)
                                            .AddClaim("EmailUsuario", login.Email)
                                            .AddClaim("idUsuario", idUsuario)
                                            .AddExpiry(Convert.ToInt16(_IConfiguration.GetSection("AutenticacaoConfig:TokenShelfLife_minutes").Value))
                                            .Builder();
            return Ok(tokenParaRetornar);
        }
    }
}
