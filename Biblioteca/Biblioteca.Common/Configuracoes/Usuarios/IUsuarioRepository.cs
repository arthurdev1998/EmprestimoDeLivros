namespace Biblioteca.Common.Configuracoes.Usuarios;

public interface IUsuarioRepository
{
    Task<bool> AuthenticateAsync(string email, string senha);
    Task<bool> UserExist(string email);
    public string GenerateToken(int id, string email);
}