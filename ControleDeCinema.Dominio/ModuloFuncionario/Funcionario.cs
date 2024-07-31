using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFuncionario;

public class Funcionario : EntidadeBase
{
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public Funcionario(string nome, string login, string senha)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
    } 

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

        Nome = funcionarioAtualizado.Nome;
        Login = funcionarioAtualizado.Login;
        Senha = funcionarioAtualizado.Senha;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrEmpty(Nome.Trim()))
            erros.Add("O campo \"Nome\" é obrigatório!");

        if (string.IsNullOrEmpty(Login.Trim()))
            erros.Add("O campo \"Login\" é obrigatório!");

        if (string.IsNullOrEmpty(Senha.Trim()))
            erros.Add("O campo \"Senha\" é obrigatório!");

        return erros;
    }

    public override string ToString()
    {
        return Nome;
    }
}

