using Biblioteca.Common.Dtos;
using Biblioteca.Service.Seguranca.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioInsertHandler _usuarioInserHandler;

    public UsuarioController(UsuarioInsertHandler usuarioInsertHandler)
    {
        _usuarioInserHandler = usuarioInsertHandler;
    }

    [HttpPost]
    //[ProducesResponseType(typeof(UsuarioDto), 200)]
    public async Task<IActionResult> Registrar(UsuarioInsertDto usuarioDto)
    {
        if (usuarioDto == null)
        {
            return BadRequest("Dados Inválidos");
        }

        // To Do metodo para validar email
         
        await _usuarioInserHandler.ExecuteAsync(usuarioDto);
        return Ok("Usuario cadastrado");
    }
}