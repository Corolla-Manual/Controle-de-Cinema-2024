using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao.ModuloIngresso;

namespace ControleDeCinema.Dominio.ModuloSessao
{
	public class Sessao : EntidadeBase
	{
		public Filme Filme { get; set; }
		public Sala Sala { get; set; }
		public DateTime Horario { get; set; }
		public int IngressosDisponiveis { get; set; }
		public StatusSessaoEnum Status { get; set; }
		public List<Ingresso> Ingressos { get; set; }

		public Sessao()
		{

		}
		public Sessao(Filme filme, Sala sala, DateTime horario, StatusSessaoEnum status)
		{
			Filme = filme;
			Sala = sala;
			Horario = horario;
			Status = status;
			IngressosDisponiveis = Sala.Capacidade;
			Ingressos = new List<Ingresso>();
		}

		public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
		{
			Sessao s = (Sessao)registroAtualizado;
			Filme = s.Filme;
			Sala = s.Sala;
			Horario = s.Horario;
			Status = s.Status;
			IngressosDisponiveis = s.IngressosDisponiveis;
			Ingressos = s.Ingressos;
		}

		public override List<string> Validar()
		{
			List<string> erros = new List<string>();

			if (Filme == null)
				erros.Add("O campo \"Filme\" é obrigatório");
			if (Sala == null)
				erros.Add("O campo \"Sala\" é obrigatório");
			if (Horario == DateTime.MinValue)
				erros.Add("O campo \"Horario\" é obrigatório");

			return erros;
		}
	}
}
