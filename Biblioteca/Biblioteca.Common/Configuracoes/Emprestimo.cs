namespace Biblioteca.Common.Configuracoes;

public class Emprestimo
{
    public int Id { get; private set; }
    public int IdCliente { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataEntrega { get; private set; }
    public bool Entregue { get; private set; }
    public Cliente? Cliente { get; set; }
    public ICollection<LivroEmprestimo>? LivrosEmprestados { get; set; }
}