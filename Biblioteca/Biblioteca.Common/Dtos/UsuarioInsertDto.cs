namespace Biblioteca.Common.Dtos;

public class UsuarioInsertDto
{
    public string? Nome { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
}