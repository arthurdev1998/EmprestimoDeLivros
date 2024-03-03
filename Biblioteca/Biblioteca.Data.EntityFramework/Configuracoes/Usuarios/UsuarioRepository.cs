using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Biblioteca.Data.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UsuarioRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<Usuario> AdicionarUsuario(Usuario usuario)
    {
        var usuarioIsExist = _context.Usuarios.Any(x => x.Email == usuario.Email);
        if (usuarioIsExist)
        {
            throw new Exception("Usuario já existe");
        }

        await _context.AddAsync(usuario);
        return usuario;
    }

    public async Task<bool> AuthenticateAsync(string email, string senha)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email!.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        if (usuario == null)
            return false;

        using var hmac = new HMACSHA512(usuario.PasswordSalt!);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

        if (!Enumerable.SequenceEqual(usuario.PasswordHash!, computedHash))
            return false;

        return true;
    }

    public string GenerateToken(int id, string email)
    {
        var claims = new[]
        {
            new Claim("id", id.ToString()),
            new Claim("email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
          };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretkey"]!));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["jwt:issuer"],
            audience: _configuration["jwt:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Task<IEnumerable<Usuario>> GetAllAsync(bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task Update(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UserExist(string email)
    {
        return await _context.Usuarios.AnyAsync(x => x.Email == email);
    }
}