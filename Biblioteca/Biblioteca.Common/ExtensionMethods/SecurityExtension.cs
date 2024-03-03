using Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;

namespace Biblioteca.Common.ExtensionMethods;

public static class SecurityExtension
{
    public static void AlterarSenha(this Usuario src, byte[] passwordHash, byte[] passwordSalt)
    {
        src.PasswordHash = passwordHash;
        src.PasswordSalt = passwordSalt;
    }
}