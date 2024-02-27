using Biblioteca.Common.Configuracoes;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController :IConfiguration
{
    public async Task<ActionResult<UserToken>> Registrar(Usuario usuario)
    {

    }
}