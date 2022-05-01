using Aplicacao.Interfaces;
using Aplicacao.Models;
using Entidades.Entidades;
using Entidades.Validadores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        public async Task<IActionResult> ListaDeUsuarios()
        {
            List<UsuarioUI> listusuarioRecuperados;

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
            UsuarioUI usuarioRecuperado;

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
                return BadRequest();

            ValidadorUsuario validador = new ValidadorUsuario();

            var resultadoValidacao = validador.Validate(usuario);

            if(!resultadoValidacao.IsValid)
                return BadRequest(resultadoValidacao.Errors);

            if (usuario.Id != Guid.Empty)
                return BadRequest("O id não deve ser preenchido para novos cadastros.");

            var emailExistente = await _IAplicacaoUsuario.VerificaUsuarioExiste(u => u.Email == usuario.Email);

            if (emailExistente)
                return Conflict();

            await _IAplicacaoUsuario.Adicionar(usuario);

            if(usuario.Id == Guid.Empty)
                return BadRequest();
            else
                return Ok(usuario);
        }
    }
}