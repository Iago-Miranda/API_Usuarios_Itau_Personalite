using Aplicacao.Interfaces;
using Aplicacao.Models;
using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAutenticacao.Models;

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
        [HttpGet]
        public async Task<IActionResult> ListaDeUsuarios()
        {
            List<UsuarioUI> listusuarioRecuperados = null;

            listusuarioRecuperados = await _IAplicacaoUsuario.ListaDeUsuariosUI();

            if (listusuarioRecuperados is null)
                return NotFound();
            else
                return Ok(listusuarioRecuperados);
        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaUsuarioPorId([FromRoute] Guid id)
        {
            UsuarioUI usuarioRecuperado = null;

            usuarioRecuperado = await _IAplicacaoUsuario.BuscarUsuarioUIPorId(id);

            if (usuarioRecuperado is null)
                return NotFound();
            else
                return Ok(usuarioRecuperado);
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

                if(usuario.Id == Guid.Empty)
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