namespace Biblioteca.Data.EntityFramework.Configuracoes.Usuarios;

public class Usuario
{
    public int Id { get; set; }
    public required string? Nome { get; set; }
    public required string? Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
   

    public void AlterarSenha(byte[] passwordHash, byte[] passowordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passowordSalt;
    }
}
