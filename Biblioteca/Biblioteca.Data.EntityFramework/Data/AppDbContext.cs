using Biblioteca.Common.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.EntityFramework.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<LivroEmprestimo> LivroEmprestimos { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       var usuario =  modelBuilder.Entity<Usuario>();

        usuario.HasKey(x => x.Id);
        usuario.Property(x => x.Email).HasMaxLength(100).IsRequired();
        usuario.Property(x => x.Nome).HasMaxLength(100).IsRequired();
    }
}