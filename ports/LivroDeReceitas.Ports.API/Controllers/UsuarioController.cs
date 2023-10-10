using LivroDeReceitas.Core.Application.interfaces.UseCase.Usuarios;
using LivroDeReceitas.Core.Application.Request.Usuario;
using LivroDeReceitas.Core.Application.Response.Usuarios;
using LivroDeReceitas.Core.Application.UseCases.Usuario.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Ports.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRegistrarUsuarioUseCase _registrarUsuarioUseCase;

        public UsuarioController(IRegistrarUsuarioUseCase registrarUsuarioUseCase)
        {
            _registrarUsuarioUseCase = registrarUsuarioUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioRegistrarResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UsuarioRegistrarRequest request)
        {
            var result = await _registrarUsuarioUseCase.Execute(request);

            if (!result.Status) return BadRequest(result);

            return Ok(result);
        }
    }
}