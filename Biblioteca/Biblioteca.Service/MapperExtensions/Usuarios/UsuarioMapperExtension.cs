using Biblioteca.Common.Dtos;
using Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;

namespace Biblioteca.Service.MapperExtensions.Usuarios;

public static class UsuarioMapperExtension
{
    public static T MapTo<T>(this Usuario src)
    {
        var usuarios = new List<Usuario> { src };
        return usuarios.MapTo<ICollection<T>>().First();
    }

    public static T MapTo<T>(this ICollection<Usuario> src)
    {
        var interfaces = typeof(T).GetInterfaces();
        if (interfaces.Any(x => x == typeof(UsuarioDto)))
        {
            return (T)(object)UsuarioDtoMapper.MapToUsusarioDto(src);
        }

        throw new Exception("Mapeamento nao implementado");
    }

    public static Usuario MapTonew(this UsuarioInsertDto dto)
    {
        return new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
        };
    }

    // public static void MapOver(this ICollection<UsuarioUpdateDto> src, ICollection<Usuario> usuarios)
    // {
    //     List<int> ids = src.Select(x => x.Id).ToList();
    //     usuarios.Where(x => !ids.Contains(x.Id)).ToList().ForEach(x => usuarios.Remove(x));
       
    //     foreach(var resource in src)
    //     {
    //         var dtos = usuarios.Where(x => x.Id == resource.Id).FirstOrDefault();
    //         if(dtos == default)
    //         {

    //         }
    //         else
    //         {

    //         }
    //     } 
    // }
}