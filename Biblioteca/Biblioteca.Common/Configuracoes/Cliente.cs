namespace Biblioteca.Common.Configuracoes;

public class Cliente
{
    public int Id { get; private set; }
    public string? CliCPF { get; private set; }
    public string? CliNome { get; private set; }
    public string? CliEndereco { get; private set; }
    public string? CliCidade { get; private set; }
    public string? CliBairro { get; private set; }
    public string? CliNumero { get; private set; }
    public string? CliTelefoneCelular { get; private set; }
    public string? CliTelefoneFixo { get; private set; }
    public bool Excluido { get; private set; }
    public ICollection<Emprestimo>? Emprestimos { get; set; }
}