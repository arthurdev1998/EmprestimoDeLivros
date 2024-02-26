namespace EmprestimoLivro.Domain.Entities;

public class Livro
{
    public int Id { get; private set; }
    public string? LivroNome { get; private set; }
    public string? LivroAutor { get; private set; }
    public string? LivroEditora { get; private set; }
    public DateTime LivroAnoPublicacao { get; private set; }
    public string? LivroEdicao { get; private set; }
    public bool Excluido { get; private set; }
    public ICollection<LivroEmprestado>? LivrosEmprestados { get; set; }

}