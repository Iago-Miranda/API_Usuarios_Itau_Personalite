using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAutenticacao.AuthToken;
using WebAPIAutenticacao.Models;

namespace WebAPIAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAplicacaoAutentica _IAplicacaoAutentica;

        public LoginController(IAplicacaoAutentica IAplicacaoAutentica)
        {
            _IAplicacaoAutentica = IAplicacaoAutentica;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/CriarToken")]
        public async Task<IActionResult> CriarToken([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                {
                    return Unauthorized();
                }

                var resultadoAutenticacao = await _IAplicacaoAutentica.ValidaCredenciais(login.Email, login.Senha);

                if (!resultadoAutenticacao)
                {
                    return Unauthorized();
                }
                else
                {
                    var tokenParaRetornar = new TokenJWTBuilder()
                                                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                                                    .AddSubject("Itau Personalite - API Usuario")
                                                    .AddIssuer("ItauPersonalite.Securiry.Bearer")
                                                    .AddClaim("EmailUsuario", login.Email)
                                                    .AddExpiry(30)
                                                    .Builder();
                    return Ok(tokenParaRetornar);
                }
            }
        }
    }
}
