using Biblioteca.Common.Dtos;
using Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;

namespace Biblioteca.Service.MapperExtensions.Usuarios;

public static class UsuarioDtoMapper
{
    public static UsuarioDto MapToUsusarioDto(Usuario src)
    {
        return new UsuarioDto
        {
            Nome = src.Nome,
            Email = src.Email
        };
    }

    public static List<UsuarioDto> MapToUsusarioDto(ICollection<Usuario> src)
    {
        return src.Select(x => MapToUsusarioDto(x)).ToList();
    }
}
