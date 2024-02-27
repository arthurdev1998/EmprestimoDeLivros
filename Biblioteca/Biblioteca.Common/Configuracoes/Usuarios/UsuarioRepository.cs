
namespace Biblioteca.Common.Configuracoes.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    public UsuarioRepository(AppDbContext)
    {
        
    }
    public Task<bool> AuthenticateAsync(string email, string senha)
    {
        throw new NotImplementedException();
    }

    public string GenerateToken(int id, string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExist(string email)
    {
        throw new NotImplementedException();
    }
}
