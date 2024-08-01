using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloSessao;

namespace ControleDeCinema.Dominio.ModuloSala;

public class Sala : EntidadeBase
{
	public int Numero { get; set; }
	public int Capacidade { get; set; }
	public List<Sessao> Sessoes { get; set; }

	public Sala(int numero, int capacidade)
	{
		Numero = numero;
		Capacidade = capacidade;

		Sessoes = new List<Sessao>();
	}

	public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
	{
		Sala salaAtualizada = (Sala)registroAtualizado;

		Numero = salaAtualizada.Numero;
		Capacidade = salaAtualizada.Capacidade;
	}

	public override List<string> Validar()
	{
		List<string> erros = new List<string>();

		if (Numero <= 0)
			erros.Add("O campo \"Numero\" é obrigatório!");

		if (Capacidade <= 0)
			erros.Add("O campo \"Capacidade\" é obrigatório!");

		return erros;
	}

	public override string ToString()
	{
		return Numero.ToString();
	}
}
