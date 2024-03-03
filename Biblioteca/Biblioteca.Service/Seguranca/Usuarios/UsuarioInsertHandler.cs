using System.Security.Cryptography;
using System.Text;
using Biblioteca.Common.Dtos;
using Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;
using Biblioteca.Service.MapperExtensions.Usuarios;

namespace Biblioteca.Service.Seguranca.Usuarios;

public class UsuarioInsertHandler
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioInsertHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioDto> ExecuteAsync(UsuarioInsertDto usuario)
    {        
        var usuarioEntity = usuario.MapTonew();

        if(usuario.Password != null)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuario.Password));
            byte[] passwrdSalt = hmac.Key;

            usuarioEntity.AlterarSenha(passwordHash,passwrdSalt );
        }
        
        var usuerIncluded = await _usuarioRepository.AdicionarUsuario(usuarioEntity);
        return usuerIncluded.MapTo<UsuarioDto>();
    }
}