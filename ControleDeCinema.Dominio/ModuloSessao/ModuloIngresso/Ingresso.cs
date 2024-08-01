using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFuncionario;

namespace ControleDeCinema.Dominio.ModuloSessao.ModuloIngresso
{
	public class Ingresso : EntidadeBase
	{
		public int NumeroPoltrona { get; set; }
		public TipoEntradaEnum Tipo { get; set; }
		public Sessao Sessao { get; set; }
		public double Valor { get; set; }
		public Funcionario Funcionario { get; set; }

		public Ingresso()
		{

		}
		public Ingresso(int numeroPoltrona, TipoEntradaEnum tipo, Sessao sessao, double valor, Funcionario funcionario)
		{
			NumeroPoltrona = numeroPoltrona;
			Tipo = tipo;
			Sessao = sessao;
			Valor = valor;
			Funcionario = funcionario;
		}

		public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
		{
			Ingresso ingre = (Ingresso)registroAtualizado;
			NumeroPoltrona = ingre.NumeroPoltrona;
			Tipo = ingre.Tipo;
			Sessao = ingre.Sessao;
			Valor = ingre.Valor;
			Funcionario = ingre.Funcionario;
		}

		public override List<string> Validar()
		{
			List<string> erros = new List<string>();

			if (NumeroPoltrona < 1)
				erros.Add("O número da poltrona não pode ser inferior a 1");
			if (Valor < 0.01)
				erros.Add("O valor do ingresso não pode ser inferior a R$0,01");
			return erros;
		}

	}
}
