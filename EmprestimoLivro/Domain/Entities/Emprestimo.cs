namespace EmprestimoLivro.Domain.Entities;

public class Emprestimo
{
    public int Id { get; private set; }
    public int IdCliente { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataEntrega { get; private set; }
    public bool Entregue { get; private set; }
    public Cliente? Cliente { get; set; }
    public ICollection<LivroEmprestado>? LivrosEmprestados { get; set; }
}
