namespace EmprestimoLivro.Domain.Entities;

public class LivroEmprestado
{
    public int Id { get; private set; }
        public int IdEmprestimo { get; private set; }
        public int IdLivro { get; private set; }
        public Livro? Livro { get; set; }
        public Emprestimo? Emprestimo { get; set; }
}
