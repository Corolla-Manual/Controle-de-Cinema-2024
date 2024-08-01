using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloSessao;

namespace ControleDeCinema.Dominio.ModuloFilme
{
	public class Filme : EntidadeBase
	{
		public string Titulo { get; set; }
		public int Duracao { get; set; }
		public string Genero { get; set; }
		public bool Estreia { get; set; }
		public List<Sessao> Sessoes { get; set; }

		public Filme()
		{

		}
		public Filme(string titulo, int duracao, string genero, bool estreia)
		{
			Titulo = titulo;
			Duracao = duracao;
			Genero = genero;
			Estreia = estreia;

			Sessoes = new List<Sessao>();
		}

		public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
		{
			Filme filmeAtualizado = (Filme)registroAtualizado;

			Titulo = filmeAtualizado.Titulo;
			Duracao = filmeAtualizado.Duracao;
			Genero = filmeAtualizado.Genero;
			Estreia = filmeAtualizado.Estreia;
		}

		public override List<string> Validar()
		{
			List<string> erros = new List<string>();

			if (string.IsNullOrEmpty(Titulo.Trim()))
				erros.Add("O campo \"Titulo\" é obrigatório!");

			if (string.IsNullOrEmpty(Genero.Trim()))
				erros.Add("O campo \"Genero\" é obrigatório!");

			if (Duracao <= 0)
				erros.Add("O campo \"Duracao\" não pode ser igual ou menor que 0!");

			return erros;
		}

		public override string ToString()
		{
			return Titulo;
		}
	}
}