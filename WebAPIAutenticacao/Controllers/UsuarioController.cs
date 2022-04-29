using Aplicacao.Interfaces;
using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAutenticacao.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAplicacaoUsuario _IAplicacaoUsuario;
        public UsuarioController(IAplicacaoUsuario IAplicacaoUsuario)
        {
            _IAplicacaoUsuario = IAplicacaoUsuario;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AdicionaUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }
            else
            {
                await _IAplicacaoUsuario.Adicionar(usuario);

                if(usuario.Id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(usuario);
                }
            }            
        }
    }
}